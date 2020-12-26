using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMarket.WebUI.Models.DTOModels
{
   public class Products
    {
        public Products()
        {
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
        public virtual ICollection<CartDetails> CartDetails { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
