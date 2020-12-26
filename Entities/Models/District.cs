using ShoppingMarket.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class District : IEntity
    {
        public District()
        {
            Users = new HashSet<Users>();
        }

        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string CustomDisctName { get; set; }
        public int? ProvId { get; set; }

        public virtual Provinces Prov { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
