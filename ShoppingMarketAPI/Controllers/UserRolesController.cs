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
    public class UserRolesController : ControllerBase
    {
        IUserRolesService _userRolesService;
        public UserRolesController(IUserRolesService userRolesService)
        {
            _userRolesService = userRolesService;
        }
        [HttpGet]
        public List<UserRoles> Get()
        {

            var userRoles = _userRolesService.GetAll();
            return userRoles;
        }
        [HttpGet("{id}")]
        public UserRoles GetRole(int id)
        {
            var userRoles = _userRolesService.GetRole(id);
            return userRoles;
        }
        [HttpPost]
        public UserRoles Post([FromBody]UserRoles userRoles)
        {
            _userRolesService.Add(userRoles);
            return userRoles;
        }
        [HttpPut]
        public UserRoles Put([FromBody]UserRoles userRoles)
        {
            _userRolesService.Update(userRoles);
            return userRoles;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var userRoles = _userRolesService.GetRole(id);
            _userRolesService.Delete(userRoles);

        }
    }
}