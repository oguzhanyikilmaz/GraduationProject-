using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ShoppingContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=LAPTOP-MIBNP62A\SQLEXPRESS;Database=ShoppingMarket; Trusted_Connection=true"); 
        //}
        //public  DbSet<Cart> Carts { get; set; }
        //public  DbSet<CartDetail> CartDetails { get; set; }
        //public  DbSet<Category> Categories { get; set; }
        //public  DbSet<Country> Countries { get; set; }
        //public  DbSet<CreditCart> CreditCarts { get; set; }
        //public  DbSet<District> Districts { get; set; }
        //public  DbSet<OrderDetail> OrderDetails { get; set; }
        //public  DbSet<Order> Orders { get; set; }
        //public  DbSet<Product> Products { get; set; }
        //public  DbSet<Province> Provinces { get; set; }
        //public  DbSet<UserRole> UserRoles { get; set; }
        //public  DbSet<User> Users { get; set; }
    }
}
