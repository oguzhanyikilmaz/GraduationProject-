using ShoppingMarket.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class CartDetails : IEntity
    {
        public int CartDetailsId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Price { get; set; }
        public int? CartId { get; set; }
        public short? Quantity { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Products Product { get; set; }
    }
}
