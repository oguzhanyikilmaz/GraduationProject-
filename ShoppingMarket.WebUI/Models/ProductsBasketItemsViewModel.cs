using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMarket.WebUI.Models
{
    public class ProductsBasketItemsViewModel
    {
        public List<BasketItem> BasketItems { get; set; }
        public List<Products> Products { get; internal set; }
    }
}
