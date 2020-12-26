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
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public List<Orders> Get()
        {
            return _orderService.GetAll();
        }
        [HttpGet("{id}")]
        public Orders GetOrder(int id)
        {
            var order = _orderService.GetOrder(id);
            return order;
        }
        [HttpPost]
        public Orders Post([FromBody]Orders order)
        {
            _orderService.Add(order);
            return order;
        }
        [HttpPut]
        public Orders Put([FromBody]Orders order)
        {
            _orderService.Update(order);
            return order;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var order = _orderService.GetOrder(id);
            _orderService.Delete(order);

        }
    }
}