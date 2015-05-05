using SimpleIoCApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIoCApp
{
    public interface IUserService : IEntityService<User>
    {
        User GetById(int id);
    }
}
