using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShoppingMarket.WebUI.Entities;
using ShoppingMarket.WebUI.Models;
using ShoppingMarket.WebUI.Models.DTOModels;

namespace ShoppingMarket.WebUI.Controllers
{
    public class HomeController : Controller
    {
        HttpClient httpClient = new HttpClient();
        private IBasketService _basketService;
        private IBasketItemService _basketItemService;
        //IOrderService _orderService;
        private UserManager<CustomIdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IBasketService basketService,IBasketItemService basketItemService,UserManager<CustomIdentityUser> userManager)
        {
            _basketService = basketService;
            _userManager = userManager;
            _basketItemService = basketItemService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var response = await httpClient.GetAsync("https://localhost:44332/api/Products");

            var apiResponse = await response.Content.ReadAsStringAsync();
            List<Products> products = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
            var result = products.OrderByDescending(p=>p.QuantitySold).Take(3);
            ProductsViewModel productListViewModel = new ProductsViewModel
            {
               
                Products = result.ToList()
               
               
            };
            return View(productListViewModel);
        }
        public IActionResult PartialBaskett()
        {
            var basket = _basketService.GetByUser(_userManager.GetUserId(User));
            var basketItems = _basketItemService.GetByBasket(Convert.ToInt32(basket.BasketId));
            BasketItemViewModel basketItemViewModel = new BasketItemViewModel()
            {
                BasketItems = basketItems
            };
            return PartialView("PartialBasketView", basketItemViewModel);
        }
        public async Task<IActionResult> ProductsListCategory(int id,int page=1)
        {
            const int pageSize = 9;
            var response = await httpClient.GetAsync("https://localhost:44332/api/Products");

            var apiResponse = await response.Content.ReadAsStringAsync();
            List<Products> products = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
            var result = products.Where(p => p.CategoryId == id).ToList();
            var res=result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ProductsViewModel productViewModel = new ProductsViewModel
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = result.Count(),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = id
                },
                Products = res.ToList()
            };
            return View(productViewModel);

        }

        public async Task<IActionResult> ProductListAll(int page=1)
        {
            const int pageSize = 9;
            var response = await httpClient.GetAsync("https://localhost:44332/api/Products");

            var apiResponse = await response.Content.ReadAsStringAsync();
            List<Products> products = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
            var result = products.Skip((page-1)*pageSize).Take(pageSize).ToList();
            ProductsViewModel productViewModel = new ProductsViewModel
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = products.Count(),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory=0

        },
                Products = result.ToList()
            };
            return View(productViewModel);

        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    


