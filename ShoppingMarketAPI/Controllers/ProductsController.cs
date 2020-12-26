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
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public List<Products> Get()
        {

            var products= _productService.GetAll(); 
            return products;
        }
        [HttpGet("{id}")]
        public Products GetProduct(int id)
        {
            var product= _productService.GetProduct(id);
            return product;
        }
        
        [HttpPost]
        public Products Post([FromBody]Products product)
        {
            _productService.Add(product);
            return product;
        }
        [HttpPut]
        public Products Put([FromBody]Products product)
        {
            _productService.Update(product);
            return product;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = _productService.GetProduct(id);
            _productService.Delete(product);

        }
    }
}