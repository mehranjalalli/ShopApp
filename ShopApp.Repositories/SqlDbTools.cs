﻿using ShopApp.RepositoryAbstracts;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ShopApp.Repositories
{
    public class SqlDbTools : IDbTools
    {
        private SqlConnectionStringBuilder connectionStringBuilder;
        private string tempDbName;

        public SqlDbTools()
        {
            RefreshConnectionString();
        }

        public async Task<bool> CheckDatabaseExists()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                    var command = connection.CreateCommand();
                    command.CommandText = "select count(*) from sys.databases where [name] = @dbname";
                    command.Parameters.Add(new SqlParameter("dbname", tempDbName));
                    var result = (int)await command.ExecuteScalarAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CheckDbConnection()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CreateDatabase(string dbScript)
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                    var command = connection.CreateCommand();
                    command.CommandText = "create database " + tempDbName;
                    await command.ExecuteNonQueryAsync();
                    connection.ChangeDatabase(tempDbName);
                    var createTablesCommand = connection.CreateCommand();
                    createTablesCommand.CommandText = dbScript.Replace("GO", "").Replace("[ShopDb]", "[" + tempDbName + "]");
                    await createTablesCommand.ExecuteNonQueryAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void RefreshConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
            connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            tempDbName = connectionStringBuilder.InitialCatalog;
            connectionStringBuilder.InitialCatalog = "master";
        }
    }
}
