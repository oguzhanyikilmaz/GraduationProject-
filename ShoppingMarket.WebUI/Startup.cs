using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingMarket.WebUI.Controllers;
using ShoppingMarket.WebUI.EmailServer;
using ShoppingMarket.WebUI.Entities;

namespace ShoppingMarket.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<CustomIdentityDbContext>(options => options.UseSqlServer("Server = LAPTOP-MIBNP62A\\SQLEXPRESS; Database =ShoppingMarkett; Trusted_Connection = True;"));
            services.AddIdentity<CustomIdentityUser, IdentityRole>().AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IBasketService, BasketManager>();
            services.AddScoped<IBasketDal, EfBasketDal>();
            services.AddScoped<IBasketItemService, BasketItemManager>();
            services.AddScoped<IBasketItemDal, EfBasketItemDal>();
            services.AddScoped<IEmailSender, SmtpEmailSender>(i=> 
            new SmtpEmailSender(
                Configuration["EmailSender:Host"],
                Configuration.GetValue<int>("EmailSender:Port"),
                Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                Configuration["EmailSender:UserName"],
                Configuration["EmailSender:Password"]
                ));
            

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                //options.SignIn.RequireConfirmedPhoneNumber = true;

            });
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/AccountController/LogOn";
                options.LogoutPath = "/Account/LogOff";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = "ShoppingMarket.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
              
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseAuthentication();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                     name: "adminroles",
                     pattern: "admin/role/list",
                     defaults: new { controller = "Admin", action = "RoleList" }
                 );

                endpoints.MapControllerRoute(
                    name: "adminrolecreate",
                    pattern: "admin/role/create",
                    defaults: new { controller = "Admin", action = "RoleCreate" }
                );
                endpoints.MapControllerRoute(
                   name: "adminroleedit",
                   pattern: "admin/role/{id?}",
                   defaults: new { controller = "Admin", action = "RoleEdit" }
               );

                endpoints.MapControllerRoute(
                    name: "productslistcategory",
                    pattern: "productslistcategory/{id?}",
                    defaults: new { controller = "Home", action = "ProductsListCategory" }
                );

                endpoints.MapControllerRoute(
                   name: "GetOrdersId",
                   pattern: "GetOrdersId/{id?}",
                   defaults: new { controller = "Orders", action = "GetOrdersId" }
               );

                endpoints.MapControllerRoute(
                   name: "getsearchproduct",
                   pattern: "getsearchproduct/{search?}",
                   defaults: new { controller = "Products", action = "GetSearchProduct" }
               );



            });


        }
    }
}
