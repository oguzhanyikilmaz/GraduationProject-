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
    public class CreditCartsController : ControllerBase
    {
        ICreditCartService _creditCartService;
        public CreditCartsController(ICreditCartService creditCartService)
        {
            _creditCartService = creditCartService;
        }
        [HttpGet]
        public List<CreditCarts> Get()
        {
            return _creditCartService.GetAll();
        }
        [HttpGet("{id}")]
        public CreditCarts Get(int id)
        {
            var cart= _creditCartService.GetCreditCart(id);
            return cart;
        }
        [HttpPost]
        public CreditCarts Post([FromBody]CreditCarts creditCart)
        {
            _creditCartService.Add(creditCart);
            return creditCart;
        }
        [HttpPut]
        public CreditCarts Put([FromBody]CreditCarts creditCart)
        {
            _creditCartService.Update(creditCart);
            return creditCart;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var creditCart = _creditCartService.GetCreditCart(id);
            _creditCartService.Delete(creditCart);

        }
    }
}