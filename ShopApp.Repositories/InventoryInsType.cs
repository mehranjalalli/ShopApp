using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShopApp.Repositories
{
    public class InventoryInsTypesRepository : DataLayer.GenericRepository<Entities.InventoryInsType>,RepositoryAbstracts.IInventoryInsTypesRepository
    {
        public InventoryInsTypesRepository() : base("name=DbConnectionString") { }
        public List<Entities.InventoryInsType> GetById(int value)
        {
            return RunQuery("SELECT * FROM[dbo].[InventoryInsTypes] WHERE [Id] = @Value", new SqlParameter("Value", value));
        }
        public List<Entities.InventoryInsType> GetByTitle(string value)
        {
            return RunQuery("SELECT * FROM[dbo].[InventoryInsTypes] WHERE [Title] LIKE @Value", new SqlParameter("Value", value));
        }
        public List<Entities.InventoryInsType> GetByDescription(string value)
        {
            return RunQuery("SELECT * FROM[dbo].[InventoryInsTypes] WHERE [Description] LIKE @Value", new SqlParameter("Value", value));
        }
        public List<Entities.InventoryInsType> GetByDeleted(bool value)
        {
            return RunQuery("SELECT * FROM[dbo].[InventoryInsTypes] WHERE [Deleted] = @Value", new SqlParameter("Value", value));
        }
        public List<Entities.InventoryInsType> GetByDeleteDate(DateTime? value)
        {
            return RunQuery("SELECT * FROM[dbo].[InventoryInsTypes] WHERE [DeleteDate] = @Value", new SqlParameter("Value", value));
        }
        public List<Entities.InventoryInsType> GetByDeletedByUserId(int? value)
        {
            return RunQuery("SELECT * FROM[dbo].[InventoryInsTypes] WHERE [DeletedByUserId] = @Value", new SqlParameter("Value", value));
        }
    }
}
