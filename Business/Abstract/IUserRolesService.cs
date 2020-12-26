using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IUserRolesService
    {
        List<UserRoles> GetAll();
        List<UserRoles> GetById(int userRoleId);
        UserRoles GetRole(int id);
        void Add(UserRoles userRoles);
        void Update(UserRoles userRoles);
        void Delete(UserRoles userRoles);
    }
}
