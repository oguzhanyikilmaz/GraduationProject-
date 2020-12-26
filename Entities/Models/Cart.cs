using ShoppingMarket.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Cart : IEntity
    {
        public Cart()
        {
            CartDetails = new HashSet<CartDetails>();
        }

        public int CartId { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? SellBy { get; set; }

        public virtual ICollection<CartDetails> CartDetails { get; set; }
    }
}
