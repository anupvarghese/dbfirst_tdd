using SimpleIoCApp.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleIoCApp.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context)
            : base(context)
        {
            
        }
        public User GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();            
        }

    }
}