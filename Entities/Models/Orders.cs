using ShoppingMarket.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Orders : IEntity
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string OrderNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Province { get; set; }
        public string Email { get; set; }
        public string Addres { get; set; }
        public string Phone { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
