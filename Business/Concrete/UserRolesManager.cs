using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserRolesManager : IUserRolesService
    {
        private IUserRolesDal _userRolesDal;
        public UserRolesManager(IUserRolesDal userRolesDal)
        {
            _userRolesDal = userRolesDal;
        }

        public void Add(UserRoles userRoles)
        {
            _userRolesDal.Add(userRoles);
        }

        public void Delete(UserRoles userRoles)
        {
            _userRolesDal.Delete(userRoles);
        }

        public List<UserRoles> GetAll()
        {
            return _userRolesDal.GetList();
        }

        public List<UserRoles> GetById(int userRoleId)
        {
            return _userRolesDal.GetList(u=>u.RoleId==userRoleId);
        }

        public UserRoles GetRole(int id)
        {
           return  _userRolesDal.Get(u => u.RoleId == id);
        }

        public void Update(UserRoles userRoles)
        {
            _userRolesDal.Update(userRoles);
        }
    }
}
