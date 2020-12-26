using ShoppingMarket.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Products : IEntity
    {
        public Products()
        {
            BasketItem = new HashSet<BasketItem>();
            CartDetails = new HashSet<CartDetails>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public short? Stock { get; set; }
        public string Barcode { get; set; }
        public int? QuantitySold { get; set; }
        public byte[] ProductImage { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<BasketItem> BasketItem { get; set; }
        public virtual ICollection<CartDetails> CartDetails { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
