using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingMarket.WebUI.Entities;
using ShoppingMarket.WebUI.Models;
using ShoppingMarket.WebUI.Models.DTOModels;

namespace ShoppingMarket.WebUI.Controllers
{
    public class OrdersController : Controller
    {
        HttpClient httpClient = new HttpClient();
        private UserManager<CustomIdentityUser> _userManager;
        public OrdersController(UserManager<CustomIdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> GetOrders()
        {
            var response = await httpClient.GetAsync("https://localhost:44332/api/Orders");

            var apiResponse = await response.Content.ReadAsStringAsync();
            List<Orders> orders = JsonConvert.DeserializeObject<List<Orders>>(apiResponse);
            var result = orders.Where(x=>x.UserId== _userManager.GetUserId(User)).ToList();
            OrdersViewModel ordersViewModel = new OrdersViewModel
            {
                Orders = result
            };
            return View(ordersViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrdersId(int id)
        {
            var response = await httpClient.GetAsync("https://localhost:44332/api/OrderDetails");

            var apiResponse = await response.Content.ReadAsStringAsync();
            List<OrderDetails> orderDetails = JsonConvert.DeserializeObject<List<OrderDetails>>(apiResponse);
            var result = orderDetails.Where(p => p.OrderId == id).ToList();
            OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel
            {
                OrderDetails = result.ToList()
            };
            return View(orderDetailsViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteFromOrderDetails(int orderDetailsId)
        {
            //Sipariş Detayı silme işlemi yazılacak....
            
            var response = await httpClient.DeleteAsync("https://localhost:44332/api/OrderDetails/" + orderDetailsId);
            return RedirectToAction("GetOrders");
        }
    }
}