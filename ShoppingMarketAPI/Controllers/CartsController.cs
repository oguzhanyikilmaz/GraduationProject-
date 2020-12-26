using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingMarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        ICartService _cartService;
        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        public List<Cart> Get()
        {
            return _cartService.GetAll();
        }
        [HttpGet("{id}")]
        public Cart GetCart(int id)
        {
            var cart = _cartService.GetCart(id);
            return cart;
        }
        [HttpPost]
        public Cart Post([FromBody]Cart cart)
        {
            _cartService.Add(cart);
            return cart;
        }
        [HttpPut]
        public Cart Put([FromBody]Cart cart)
        {
            _cartService.Update(cart);
            return cart;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cart = _cartService.GetCart(id);
            _cartService.Delete(cart);

        }
    }
}