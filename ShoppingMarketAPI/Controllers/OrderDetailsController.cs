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
    public class OrderDetailsController : ControllerBase
    {
        IOrderDetailService _orderDetailService;
        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        [HttpGet]
        public List<OrderDetails> Get()
        {
            return _orderDetailService.GetAll();
        }
        [HttpGet("{id}")]
        public List<OrderDetails> GetOrderDetails(int id)
        {
            var orderdetail = _orderDetailService.GetOrderDetail(id);
            return orderdetail;
        }
        [HttpPost]
        public OrderDetails Post([FromBody]OrderDetails orderDetail)
        {
            _orderDetailService.Add(orderDetail);
            return orderDetail;
        }
        [HttpPut]
        public OrderDetails Put([FromBody]OrderDetails orderDetail)
        {
            _orderDetailService.Update(orderDetail);
            return orderDetail;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var orderDetails = _orderDetailService.GetAll();
            var orderDetail = orderDetails.Where(x=>x.OrderDetailsId==id);
            foreach (var item in orderDetail)
            {
                _orderDetailService.Delete(item); 
            }
           

        }
    }
}