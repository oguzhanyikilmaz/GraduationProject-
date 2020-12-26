using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.RequestLibrary.DTOModels
{
    public class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
