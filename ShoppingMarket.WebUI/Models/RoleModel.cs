using Microsoft.AspNetCore.Identity;
using ShoppingMarket.WebUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMarket.WebUI.Models
{
    public class RoleModel
    {
        public string Name { get; set; }
    }
    public class RoleDetails
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<CustomIdentityUser> Members { get; set; }
        public IEnumerable<CustomIdentityUser> NonMembers { get; set; }
    }

    public class RoleEditModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}
