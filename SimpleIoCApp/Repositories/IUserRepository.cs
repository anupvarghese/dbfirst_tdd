using SimpleIoCApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIoCApp.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetById(int id);
    }
}
