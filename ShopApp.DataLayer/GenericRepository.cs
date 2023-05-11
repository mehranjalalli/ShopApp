using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataLayer
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
    {
        protected string schema;
        protected string tableName;

        string connectionString;

        List<PropertyModel> propertyModels = new List<PropertyModel>();

        public GenericRepository()
        {
            var entityType = typeof(TEntity);
            var tableAttribute = entityType.GetCustomAttributes(typeof(TableAttribute), false).OfType<TableAttribute>().FirstOrDefault();
            if(tableAttribute != null)
            {
                schema = tableAttribute.Schema;
                tableName = tableAttribute.Table;
            }
            else
            {
                schema = "dbo";
                tableName = entityType.Name;
            }
            foreach(var propertyInfo in entityType.GetProperties())
            {
                var propertyModel = new PropertyModel
                {
                    PropertyName = propertyInfo.Name,
                    ColumnName = propertyInfo.Name,
                    IsComputed = propertyInfo.GetCustomAttributes(typeof(ComputedColumnAttribute), false).Any(),
                    IsPrimaryKey = propertyInfo.GetCustomAttributes(typeof(PrimaryKeyAttribute), false).Any(),
                    PropertyInfo = propertyInfo
                };
                propertyModels.Add(propertyModel);
            }
        }

        public GenericRepository(string connectionString) : this()
        {
            if (connectionString.StartsWith("name="))
            {
                this.connectionString = ConfigurationManager.ConnectionStrings[connectionString.Substring(5)].ConnectionString;
            }
            else
            {
                this.connectionString = connectionString;
            }
        }

        public int Add(TEntity entity)
        {
            StringBuilder insertStatement = new StringBuilder("INSERT INTO [" + schema + "].[" + tableName + "] ({columns}){output} VALUES ({values})");

            List<string> columnNames = new List<string>();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<string> sqlParameterNames = new List<string>();

            var parameterCounter = 1;
            foreach(var property in propertyModels)
            {
                if (property.IsComputed)
                    continue;
                columnNames.Add(property.ColumnName);
                var parameterName = "Column" + parameterCounter++;
                sqlParameterNames.Add(parameterName);
                var propertyValue = property.PropertyInfo.GetValue(entity);
                sqlParameters.Add(new SqlParameter(parameterName, propertyValue == null ? DBNull.Value : propertyValue));
            }

            var computedColumns = propertyModels.Where(p => p.IsComputed).ToList();
            if (!computedColumns.Any())
                insertStatement.Replace("{output}", "");
            else
            {
                insertStatement.Replace("{output}", " OUTPUT " + string.Join(",", computedColumns.Select(c => "inserted.[" + c.ColumnName + "]")));
            }

            insertStatement.Replace("{columns}", string.Join(",", columnNames.Select(col => "[" + col + "]")));

            insertStatement.Replace("{values}", string.Join(",", sqlParameterNames.Select(paramerter => "@" + paramerter)));

            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = insertStatement.ToString();
                foreach(var parameter in sqlParameters)
                {
                    command.Parameters.Add(parameter);
                }
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foreach (var col in computedColumns)
                    {
                        var value = reader[col.ColumnName];
                        if (value is DBNull)
                            col.PropertyInfo.SetValue(entity, null);
                        else
                            col.PropertyInfo.SetValue(entity, value);
                    }
                }
                return 1;
            }
        }

        public int Remove(TEntity entity)
        {
            var primaryKeys = propertyModels.Where(property => property.IsPrimaryKey);

            StringBuilder deleteStatement = new StringBuilder("DELETE FROM [" + schema + "].[" + tableName + "]");

            List<string> whereParts = new List<string>();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();


            var parameterCounter = 1;
            foreach (var property in primaryKeys)
            {
                var parameterName = "Column" + parameterCounter++;
                whereParts.Add("[" + property.ColumnName + "] = @" + parameterName);
                var propertyValue = property.PropertyInfo.GetValue(entity);
                sqlParameters.Add(new SqlParameter(parameterName, propertyValue));
            }

            deleteStatement.Append(" WHERE " + string.Join(" AND ", whereParts));

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = deleteStatement.ToString();
                foreach (var parameter in sqlParameters)
                {
                    command.Parameters.Add(parameter);
                }
                return command.ExecuteNonQuery();
            }
        }

        public TEntity Find(params object[] keys)
        {
            var primaryKeys = propertyModels.Where(property => property.IsPrimaryKey);

            var query = new StringBuilder("SELECT TOP(1) * FROM [" + schema + "].[" + tableName + "]");

            List<string> whereParts = new List<string>();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            var parameterCounter = 1;
            foreach (var property in primaryKeys)
            {
                var parameterName = "Column" + parameterCounter;
                whereParts.Add("[" + property.ColumnName + "] = @" + parameterName);
                var propertyValue = keys[parameterCounter++ - 1];
                sqlParameters.Add(new SqlParameter(parameterName, propertyValue));
            }

            query.Append(" WHERE " + string.Join(" AND ", whereParts));

            return RunQuery(query.ToString(), sqlParameters.ToArray()).FirstOrDefault();
        }

        public List<TEntity> All()
        {
            var query = new StringBuilder("SELECT * FROM [" + schema + "].[" + tableName + "]");

            return RunQuery(query.ToString());
        }

        public int Count()
        {
            var query = new StringBuilder("SELECT COUNT(*) FROM ["+schema+"].["+tableName+"]");
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query.ToString(),connection);
                return (int) command.ExecuteScalar();
            }
        }

        public int Update(TEntity entity)
        {
            var query = new StringBuilder("UPDATE ["+schema+"].["+tableName+"]");

            var nonComputedColumn = propertyModels.Where(p => !p.IsComputed);

            var primaryKeys = propertyModels.Where(property => property.IsPrimaryKey);

            List<string> updateStatements = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();

            var valueCounter = 1;
            foreach (var model in nonComputedColumn)
            {
                updateStatements.Add("[" + model.ColumnName + "] = @Value" + valueCounter);
                var value = model.PropertyInfo.GetValue(entity);
                parameters.Add(new SqlParameter("Value" + valueCounter++, value == null ? DBNull.Value : value));
            }

            query.Append(" SET " + string.Join(",", updateStatements));

            var computedColumns = propertyModels.Where(p => p.IsComputed).ToList();
            if (computedColumns.Any())
            {
                query.Append(" OUTPUT " + string.Join(",", computedColumns.Select(c => "inserted.[" + c.ColumnName + "]")));
            }
            List<string> whereParts = new List<string>();
            var keyCounter = 1;
            foreach (var property in primaryKeys)
            {
                var parameterName = "Column" + keyCounter++;
                whereParts.Add("[" + property.ColumnName + "] = @" + parameterName);
                var propertyValue = property.PropertyInfo.GetValue(entity);
                parameters.Add(new SqlParameter(parameterName, propertyValue));
            }

            query.Append(" WHERE " + string.Join(" AND ", whereParts));


            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = query.ToString();
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foreach (var col in computedColumns)
                    {
                        var value = reader[col.ColumnName];
                        if (value is DBNull)
                            col.PropertyInfo.SetValue(entity, null);
                        else
                            col.PropertyInfo.SetValue(entity, value);
                    }
                }
                return 1;
            }
        }

        protected List<TEntity> RunQuery(string query, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = query.ToString();
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                var reader = command.ExecuteReader();

                List<TEntity> entities = new List<TEntity>();

                while (reader.Read())
                {
                    TEntity entity = Activator.CreateInstance<TEntity>();

                    foreach (var model in propertyModels)
                    {
                        var value = reader[model.ColumnName];
                        if (value is DBNull)
                            model.PropertyInfo.SetValue(entity, null);
                        else
                            model.PropertyInfo.SetValue(entity, value);
                    }

                    entities.Add(entity);
                }

                return entities;
            }
        }
    }
}
