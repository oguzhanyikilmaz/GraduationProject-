using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMarket.WebUI.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
            BasketItem = new List<BasketItem>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Province { get; set; }
        public string Email { get; set; }
        public string Addres { get; set; }
        public string Phone { get; set; }
        public decimal? TotalAmount { get; set; }
        public List<BasketItem> BasketItem { get; set; }
    }
}
