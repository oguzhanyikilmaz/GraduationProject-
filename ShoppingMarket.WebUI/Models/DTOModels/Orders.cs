using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;


namespace ShoppingMarket.WebUI.Models.DTOModels
{
    public class Orders
    {
        public Orders()
        {
            OrderDetails = new List<OrderDetails>();
            BasketItem = new List<BasketItem>();
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

        public virtual List<OrderDetails> OrderDetails { get; set; }
        public List<BasketItem> BasketItem { get; set; }
    }
}
