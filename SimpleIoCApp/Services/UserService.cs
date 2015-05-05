using SimpleIoCApp.Repositories;
using SimpleIoCApp.Repository;
using SimpleIoCApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIoCApp
{
    public class UserService : EntityService<User>, IUserService
    {
        IUnitOfWork _unitOfWork;
        IUserRepository _userRepo;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepo)
            : base(unitOfWork, userRepo)
       {
           _unitOfWork = unitOfWork;
           _userRepo = userRepo;
       }

        public User GetById(int Id)
        {
            return _userRepo.GetById(Id);
        }
    }
}
