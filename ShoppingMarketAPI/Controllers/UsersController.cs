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
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public List<Users> Get()
        {
            return _userService.GetAll();
        }
        [HttpPost]
        public Users Post([FromBody]Users user)
        {
            _userService.Add(user);
            return user;
        }
        [HttpPut]
        public Users Put([FromBody]Users user)
        {
            _userService.Update(user);
            return user;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = _userService.GetUser(id);
            _userService.Delete(user);

        }
    }
}