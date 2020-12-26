using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMarket.WebUI.Models
{
    public class BasketModel
    {
        public int BasketId { get; set; }
        public List<BasketItemModel> BasketItems { get; set; }

       
    }

    

}
