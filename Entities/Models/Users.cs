using ShoppingMarket.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Users : IEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public string Addres { get; set; }
        public int? DistrictId { get; set; }

        public virtual District District { get; set; }
        public virtual UserRoles Role { get; set; }
    }
}
