using BusinessEntities;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> Get(UserTypes? userType = null, string name = null, string email = null, string tag = null);
        User GetById(Guid id);
        void DeleteAll();
    }
}