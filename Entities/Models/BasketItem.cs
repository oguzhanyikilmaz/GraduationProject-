using ShoppingMarket.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class BasketItem : IEntity
    {
        public int OrderDetailsId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Price { get; set; }
        public int? BasketId { get; set; }
        public short? Quantity { get; set; }

        public virtual Basket Basket { get; set; }
        public virtual Products Product { get; set; }
    }
}
