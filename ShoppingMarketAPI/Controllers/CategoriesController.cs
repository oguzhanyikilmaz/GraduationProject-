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
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public List<Categories> Get()
        {
            return _categoryService.GetAll();
        }
        [HttpGet("{id}")]
        public Categories Get(int id)
        {
            var category = _categoryService.GetCategory(id);
            return category;
        }
        [HttpPost]
        public Categories Post([FromBody]Categories category)
        {
            _categoryService.Add(category);
            return category;
        }
        [HttpPut]
        public Categories Put([FromBody]Categories category)
        {
            _categoryService.Update(category);
            return category;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var category = _categoryService.GetCategory(id);
             _categoryService.Delete(category);

        }
    }
}