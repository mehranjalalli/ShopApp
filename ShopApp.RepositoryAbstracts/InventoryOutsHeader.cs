using System;
using System.Collections.Generic;

namespace ShopApp.RepositoryAbstracts
{
    public interface IInventoryOutsHeadersRepository : DataLayer.IRepository<Entities.InventoryOutsHeader>
    {
        List<Entities.InventoryOutsHeader> GetById(long value);
        List<Entities.InventoryOutsHeader> GetByInventoryId(int value);
        List<Entities.InventoryOutsHeader> GetByTypeId(int value);
        List<Entities.InventoryOutsHeader> GetByTitle(string value);
        List<Entities.InventoryOutsHeader> GetByDescription(string value);
        List<Entities.InventoryOutsHeader> GetByDate(DateTime value);
        List<Entities.InventoryOutsHeader> GetByAccepted(bool value);
        List<Entities.InventoryOutsHeader> GetByAcceptDate(DateTime? value);
        List<Entities.InventoryOutsHeader> GetByAcceptedByUserId(int? value);
        List<Entities.InventoryOutsHeader> GetByDeleted(bool value);
        List<Entities.InventoryOutsHeader> GetByDeleteDate(DateTime? value);
        List<Entities.InventoryOutsHeader> GetByDeletedByUserId(int? value);
    }
}
