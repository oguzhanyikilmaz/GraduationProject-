using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Adminn.Models
{
   public class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public string Addres { get; set; }
        public int? DistrictId { get; set; }

        public virtual Districts District { get; set; }
        public virtual UserRoles Role { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
