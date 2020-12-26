using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingMarket.WebUI.Extensions;
using ShoppingMarket.WebUI.Models;
using ShoppingMarket.WebUI.Models.DTOModels;

namespace ShoppingMarket.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        HttpClient httpClient = new HttpClient();
        public async  Task<IActionResult> Get()
        {
            var response = await httpClient.GetAsync("https://localhost:44332/api/Products");
            
                var apiResponse = await response.Content.ReadAsStringAsync();
                List<Products> products = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
            ProductsViewModel productListViewModel = new ProductsViewModel
            {
                Products = products
            };
            return View(productListViewModel);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var response = await httpClient.GetAsync("https://localhost:44332/api/Products");

            var apiResponse = await response.Content.ReadAsStringAsync();
            List<Products> products = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
            var result = products.Where(p => p.ProductId == id);
            ProductsViewModel productListViewModel = new ProductsViewModel 
            {
                Products = result.ToList()
            };
            return View(productListViewModel);
        }

        public async Task<IActionResult> GetSearchProduct(string search, int page=1)
        {
            const int pageSize = 2;
            var response = await httpClient.GetAsync("https://localhost:44332/api/Products");

            var apiResponse = await response.Content.ReadAsStringAsync();
            List<Products> products = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
            var result = products.Where(p => p.ProductName.ToLower()==search.ToLower()).ToList();
            if (result.Count==0)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Ürün Bulunamadı",
                    Message = "Maalesef aradığınızı bulamadık... :(",
                    AlertType = "warning"
                });
                RedirectToAction("Index","Home");
            }          
            var res = result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ProductsViewModel productViewModel = new ProductsViewModel
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = result.Count(),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    
                },
                Products = res.ToList()
            };
            return View(productViewModel);
        }


    }
}