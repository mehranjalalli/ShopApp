using System;
using System.Collections.Generic;

namespace ShopApp.RepositoryAbstracts
{
    public interface IFinancialYearsRepository : DataLayer.IRepository<Entities.FinancialYear>
    {
        List<Entities.FinancialYear> GetById(int value);
        List<Entities.FinancialYear> GetByCorporationId(int value);
        List<Entities.FinancialYear> GetByTitle(string value);
        List<Entities.FinancialYear> GetByDescription(string value);
        List<Entities.FinancialYear> GetByStartDate(DateTime value);
        List<Entities.FinancialYear> GetByFinishDate(DateTime value);
        List<Entities.FinancialYear> GetByIsClosed(bool value);
        List<Entities.FinancialYear> GetByCloseDate(DateTime? value);
        List<Entities.FinancialYear> GetByClosedByUserId(int? value);
        List<Entities.FinancialYear> GetByDeleted(bool value);
        List<Entities.FinancialYear> GetByDeleteDate(DateTime? value);
        List<Entities.FinancialYear> GetByDeletedByUserId(int? value);
    }
}
