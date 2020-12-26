using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.RequestLibrary.DTOModels
{
   public class Cart
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
