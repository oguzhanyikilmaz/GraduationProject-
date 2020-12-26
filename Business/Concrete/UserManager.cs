using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(Users user)
        {
            _userDal.Add(user);
        }

        public void Delete(Users user)
        {
            _userDal.Delete(user);
        }

        public List<Users> GetAll()
        {
            return _userDal.GetList();
        }

        public Users GetUser(int id)
        {
            return _userDal.Get(u => u.UserId == id);
        }

       

        public void Update(Users user)
        {
            _userDal.Update(user);
        }
    }
}
