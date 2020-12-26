using ShoppingMarket.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class UserRoles : IEntity
    {
        public UserRoles()
        {
            Users = new HashSet<Users>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
