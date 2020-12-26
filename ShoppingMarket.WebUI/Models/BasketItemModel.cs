using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMarket.WebUI.Models
{
    public class BasketItemModel
    {
        
            public int BasketItemId { get; set; }
            public int ProductId { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public string ImageUrl { get; set; }
            public int Quantity { get; set; }
             public double TotalPrice()
             {
            return Price*Quantity;
             }

    }
}
