using ShoppingMarket.WebUI.Models.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMarket.WebUI.Models
{
    public class CartViewModel
    {
        public List<Cart> Cart { get; internal set; }
    }
}
