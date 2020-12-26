using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Models;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingMarket.WebUI.Entities;
using ShoppingMarket.WebUI.Extensions;
using ShoppingMarket.WebUI.Models;
using ShoppingMarket.WebUI.Models.DTOModels;
using BasketItem = Entities.Models.BasketItem;

namespace ShoppingMarket.WebUI.Controllers
{
    
    public class BasketsController : Controller
    {
        System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
        private IBasketService _basketService;
        private IBasketItemService _basketItemService;
        //IOrderService _orderService;
        private UserManager<CustomIdentityUser> _userManager;
        public BasketsController(IBasketService basketService, UserManager<CustomIdentityUser> userManager, IBasketItemService basketItemService/*,IOrderService orderService*/)
        {
            _basketService = basketService;
            _userManager = userManager;
            _basketItemService = basketItemService;
            //_orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var basket = _basketService.GetByUser(_userManager.GetUserId(User));
            var basketItems = _basketItemService.GetByBasket(Convert.ToInt32(basket.BasketId));
            BasketItemViewModel basketItemViewModel = new BasketItemViewModel()
            {
                BasketItems=basketItems              
            };
            
            return View(basketItemViewModel);
            

        }
       
        [HttpPost]
        public async Task<IActionResult> Add(int productId, int quantity)
        {
            var response = await httpClient.GetAsync("https://localhost:44332/api/Products/"+productId);

            var apiResponse = await response.Content.ReadAsStringAsync();
            Models.DTOModels.Products product = JsonConvert.DeserializeObject<Models.DTOModels.Products>(apiResponse);
            var basket = _basketService.GetByUser(_userManager.GetUserId(User));
            var basketItems = _basketItemService.GetByBasket(Convert.ToInt32(basket.BasketId));
            var index =  basketItems.Where(i => i.ProductId == productId).ToList();
            if (index.Count==0)
            {
                var result = new BasketItem()
                {
                    ProductId = productId,
                    Quantity = Convert.ToInt16(quantity),
                    BasketId = basket.BasketId, 
                    Price= product.Price                
                      
                };
                _basketItemService.Add(result);
            }
            foreach (var item in index)
            {
                item.Quantity += 1;
                _basketItemService.Update(item);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Ürün Sepete Eklendi.",
                Message = "",
                AlertType = "warning"
            });
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult DeleteFromBasket(int productId)
        {
            var basket = _basketService.GetByUser(_userManager.GetUserId(User));
            _basketItemService.DeleteId(basket.BasketId, productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult QuantityChange(int productId)
        {
            var basket = _basketService.GetByUser(_userManager.GetUserId(User));
            _basketItemService.DeleteId(basket.BasketId, productId);
            return RedirectToAction("Index");
        }
        public IActionResult CheckOut()
        {
            var basket = _basketService.GetByUser(_userManager.GetUserId(User));
            var basketItems = _basketItemService.GetByBasket(Convert.ToInt32(basket.BasketId));
            var orderModel = new OrderModel(); 
            foreach (var item in basketItems)
            {
                
                orderModel.BasketItem.Add(item);
            }
            return View(orderModel);
        }
        [HttpPost]
        public async Task<IActionResult> CheckOut(OrderModel model) 
        {
            try
            {
                var basket = _basketService.GetByUser(_userManager.GetUserId(User));
                var basketItems = _basketItemService.GetByBasket(Convert.ToInt32(basket.BasketId));
                Models.DTOModels.Orders orders = new Models.DTOModels.Orders();
                orders.FirstName = model.FirstName;
                orders.UserId = _userManager.GetUserId(User);
                orders.LastName = model.LastName;
                orders.Email = model.Email;
                orders.Addres = model.Addres;
                orders.Phone = model.Phone;
                orders.Province = model.Province;
                orders.TotalAmount = basketItems.Sum(i => i.Price * i.Quantity);
                var convertModel = JsonConvert.SerializeObject(orders);
                var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                var response = await httpClient.PostAsync("https://localhost:44332/api/Orders", content);

                using (var res = await httpClient.GetAsync("https://localhost:44332/api/Orders"))
                {
                    var apiResponse = await res.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject(apiResponse);
                    List<Models.DTOModels.Orders> carts = JsonConvert.DeserializeObject<List<Models.DTOModels.Orders>>(apiResponse);
                    int son_id = int.Parse(carts
                      .OrderByDescending(p => p.OrderId)
                      .Select(r => r.OrderId)
                      .First().ToString()
                          );

                    foreach (var item in basketItems)
                    {
                        Models.DTOModels.OrderDetails orderDetails = new Models.DTOModels.OrderDetails();
                        orderDetails.OrderId =Convert.ToInt32(son_id);
                        orderDetails.ProductId = item.ProductId;
                        orderDetails.Price = item.Price;
                        orderDetails.Quantity = item.Quantity;
                        var convertt = JsonConvert.SerializeObject(orderDetails);
                        var contt = new StringContent(convertt, Encoding.UTF8, "application/json");
                        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                        var resp = await httpClient.PostAsync("https://localhost:44332/api/OrderDetails", contt);
                    }
                }
                foreach (var item in basketItems)
                {
                    _basketItemService.DeleteId(basket.BasketId, Convert.ToInt32(item.ProductId));
                }
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Ödeme Başarıyla Gerçekleşti",
                    Message = "",
                    AlertType = "warning"
                });
                
                return RedirectToAction("Index", "Home");
                
                
            }
            catch (Exception)
            {

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Ödeme Gerçekleşmedi !",
                    Message = "",
                    AlertType = "warning"
                });
                return RedirectToAction("Index", "Home");
            }
            
            
        }
        


       

        //private Payment PaymentProcess(OrderModel orderModel)
        //{
        //    Options options = new Options();
        //    options.ApiKey = "sandbox-3bLsAkakPgwc48XHPfMpkc5BFiGeMsPP";
        //    options.SecretKey = "sandbox-qAe37f7gGGx5vozpvKEBmA1THR4wKR4D";
        //    options.BaseUrl = "https://sandbox-api.iyzipay.com";

        //    CreatePaymentRequest request = new CreatePaymentRequest();
        //    request.Locale = Locale.TR.ToString();
        //    request.ConversationId = "123456789";
        //    request.Price = "1";
        //    request.PaidPrice = "1.2";
        //    request.Currency = Currency.TRY.ToString();
        //    request.Installment = 1;
        //    request.BasketId = "B67832";
        //    request.PaymentChannel = PaymentChannel.WEB.ToString();
        //    request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

        //    PaymentCard paymentCard = new PaymentCard();
        //    paymentCard.CardHolderName = "John Doe";
        //    paymentCard.CardNumber = "5528790000000008";
        //    paymentCard.ExpireMonth = "12";
        //    paymentCard.ExpireYear = "2030";
        //    paymentCard.Cvc = "123";
        //    paymentCard.RegisterCard = 0;
        //    request.PaymentCard = paymentCard;

        //    Buyer buyer = new Buyer();
        //    buyer.Id = "BY789";
        //    buyer.Name = "John";
        //    buyer.Surname = "Doe";
        //    buyer.GsmNumber = "+905350000000";
        //    buyer.Email = "email@email.com";
        //    buyer.IdentityNumber = "74300864791";
        //    buyer.LastLoginDate = "2015-10-05 12:43:35";
        //    buyer.RegistrationDate = "2013-04-21 15:12:09";
        //    buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        //    buyer.Ip = "85.34.78.112";
        //    buyer.City = "Istanbul";
        //    buyer.Country = "Turkey";
        //    buyer.ZipCode = "34732";
        //    request.Buyer = buyer;

        //    Address shippingAddress = new Address();
        //    shippingAddress.ContactName = "Jane Doe";
        //    shippingAddress.City = "Istanbul";
        //    shippingAddress.Country = "Turkey";
        //    shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        //    shippingAddress.ZipCode = "34742";
        //    request.ShippingAddress = shippingAddress;

        //    Address billingAddress = new Address();
        //    billingAddress.ContactName = "Jane Doe";
        //    billingAddress.City = "Istanbul";
        //    billingAddress.Country = "Turkey";
        //    billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        //    billingAddress.ZipCode = "34742";
        //    request.BillingAddress = billingAddress;

        //    List<Iyzipay.Model.BasketItem> basketItems = new List<Iyzipay.Model.BasketItem>();
        //    Iyzipay.Model.BasketItem firstBasketItem = new Iyzipay.Model.BasketItem();
        //    firstBasketItem.Id = "BI101";
        //    firstBasketItem.Name = "Binocular";
        //    firstBasketItem.Category1 = "Collectibles";
        //    firstBasketItem.Category2 = "Accessories";
        //    firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
        //    firstBasketItem.Price = "0.3";
        //    basketItems.Add(firstBasketItem);

        //    Iyzipay.Model.BasketItem secondBasketItem = new Iyzipay.Model.BasketItem();
        //    secondBasketItem.Id = "BI102";
        //    secondBasketItem.Name = "Game code";
        //    secondBasketItem.Category1 = "Game";
        //    secondBasketItem.Category2 = "Online Game Items";
        //    secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
        //    secondBasketItem.Price = "0.5";
        //    basketItems.Add(secondBasketItem);

        //    Iyzipay.Model.BasketItem thirdBasketItem = new Iyzipay.Model.BasketItem();
        //    thirdBasketItem.Id = "BI103";
        //    thirdBasketItem.Name = "Usb";
        //    thirdBasketItem.Category1 = "Electronics";
        //    thirdBasketItem.Category2 = "Usb / Cable";
        //    thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
        //    thirdBasketItem.Price = "0.2";
        //    basketItems.Add(thirdBasketItem);
        //    request.BasketItems = basketItems;

        //    return  Payment.Create(request, options);
        //}
    }
    
}
