using ShoppingMarket.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Countries : IEntity
    {
        public Countries()
        {
            Provinces = new HashSet<Provinces>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Provinces> Provinces { get; set; }
    }
}
