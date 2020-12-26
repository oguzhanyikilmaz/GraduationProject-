using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingMarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        IDistrictsService _districtsService;
        public DistrictsController(IDistrictsService districtsService)
        {
            _districtsService = districtsService;
        }
        [HttpGet]
        public List<District> Get()
        {

            var districts = _districtsService.GetAll();
            return districts;
        }
        [HttpGet("{id}")]
        public District GetDistrict(int id)
        {
            var district = _districtsService.GetDistrict(id);
            return district;
        }
        [HttpPost]
        public District Post([FromBody]District district)
        {
            _districtsService.Add(district);
            return district;
        }
        [HttpPut]
        public District Put([FromBody]District district)
        {
            _districtsService.Update(district);
            return district;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var district = _districtsService.GetDistrict(id);
            _districtsService.Delete(district);

        }
    }
}