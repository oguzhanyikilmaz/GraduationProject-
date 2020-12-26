using ShoppingMarket.WebUI.Models.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMarket.WebUI.Models
{
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentCategory { get; set; }
       public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems/ItemsPerPage);
        }
    }
    public class ProductsViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Products> Products { get; internal set; }
    }
}
