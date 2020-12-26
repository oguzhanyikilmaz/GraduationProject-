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
    public class CartDetailsController : ControllerBase
    {
        ICartDetailService _cartDetailService;
        public CartDetailsController(ICartDetailService cartDetailService)
        {
            _cartDetailService = cartDetailService;
        }
        [HttpGet]
        public List<CartDetails> Get()
        {
            return _cartDetailService.GetAll();
        }
        [HttpGet("{id}")]
        public CartDetails GetCartDetails(int id)
        {
            var cartdetail = _cartDetailService.GetCartDetail(id);
            return cartdetail;
        }
        [HttpPost]
        public CartDetails Post([FromBody]CartDetails cartDetail)
        {
            _cartDetailService.Add(cartDetail);
            return cartDetail;
        }
        [HttpPut]
        public CartDetails Put([FromBody]CartDetails cartDetail)
        {
            _cartDetailService.Update(cartDetail);
            return cartDetail;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cartDetail = _cartDetailService.GetCartDetail(id);
            _cartDetailService.Delete(cartDetail);

        }
    }
}