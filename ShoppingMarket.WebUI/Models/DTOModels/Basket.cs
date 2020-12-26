using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMarket.WebUI.Models.DTOModels
{
    public class Basket
    {
        public Basket()
        {
            BasketItem = new List<BasketItem>();
        }

        public int BasketId { get; set; }
        public string UserId { get; set; }

        public virtual List<BasketItem> BasketItem { get; set; }
    }
}
