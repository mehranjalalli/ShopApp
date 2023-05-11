using System;
using System.Collections.Generic;

namespace ShopApp.RepositoryAbstracts
{
    public interface IUsersRepository : DataLayer.IRepository<Entities.User>
    {
        List<Entities.User> GetById(int value);
        List<Entities.User> GetByUsername(string value);
        List<Entities.User> GetByDeleted(bool value);
        List<Entities.User> GetByDeleteDate(DateTime? value);
        List<Entities.User> GetByDeletedByUserId(int? value);
    }
}
