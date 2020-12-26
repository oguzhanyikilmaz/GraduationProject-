using ShoppingMarket.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Basket:IEntity
    {
        public Basket()
        {
            BasketItem = new HashSet<BasketItem>();
        }

        public int BasketId { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<BasketItem> BasketItem { get; set; }
    }
}
