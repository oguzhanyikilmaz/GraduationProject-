using ShoppingMarket.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class OrderDetails : IEntity
    {
        public int OrderDetailsId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Price { get; set; }
        public int? OrderId { get; set; }
        public short? Quantity { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
