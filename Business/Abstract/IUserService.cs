using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<Users> GetAll();
        Users GetUser(int id);
        void Add(Users user);
        void Update(Users user);
        void Delete(Users user);
    
    }
}
