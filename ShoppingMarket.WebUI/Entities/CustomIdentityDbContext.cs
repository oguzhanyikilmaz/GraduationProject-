using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMarket.WebUI.Entities
{
    public class CustomIdentityDbContext:IdentityDbContext<CustomIdentityUser>
    {
        public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext> options): base(options)
        {

        }
    }
}
