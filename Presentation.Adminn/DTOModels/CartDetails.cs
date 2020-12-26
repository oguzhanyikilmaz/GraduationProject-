using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Adminn.Models
{
   public class CartDetails
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
