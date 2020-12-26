using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Business.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShoppingMarket.WebUI.EmailServer;
using ShoppingMarket.WebUI.Entities;
using ShoppingMarket.WebUI.Extensions;
using ShoppingMarket.WebUI.Models;

namespace ShoppingMarket.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        //private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomIdentityUser> _signInManager;
        private IEmailSender _emailSender;
        private IBasketService _basketService;
      
        public AccountController(UserManager<CustomIdentityUser> userManager/*, RoleManager<CustomIdentityRole> roleManager*/, SignInManager<CustomIdentityUser> signInManager, IEmailSender emailSender, IBasketService basketService)
        {
            _userManager = userManager;
            //_roleManager = roleManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _basketService = basketService;
           
        }
        public IActionResult LogOn(string ReturnUrl=null)
        {
            return View(new LoginViewModel() { 
                    ReturnUrl=ReturnUrl
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOn(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {

                return View(loginViewModel);
            }
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user==null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Bilgilerinizi gözden geçiriniz !",
                    Message = "",
                    AlertType = "warning"
                });
                return View(loginViewModel);
            }
           
            var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password,true,false);
            if (result.Succeeded)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Hoşgeldiniz :)",
                    Message = "",
                    AlertType = "warning"
                });
                Redirect(loginViewModel.ReturnUrl?? "~/");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Hoşgeldiniz :)",
                Message = "",
                AlertType = "warning"
            });
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            var user = new CustomIdentityUser
            {
                FirstName = registerViewModel.FirstName,
                LastName= registerViewModel.LastName,
                UserName= registerViewModel.UserName,             
                Email= registerViewModel.Email

            };
            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                _basketService.InitializeCart(user.Id);
                return RedirectToAction("LogOn", "Account");    
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Bilgilerinizi Kontrol Ediniz",
                Message = "",
                AlertType = "warning"
            });
            return View(registerViewModel);
           
        }

        public IActionResult ForgotPassword()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.To.Add(user.Email);
                mail.From = new MailAddress("oguzhanyklmz27@gmail.com", "Şifre Güncelleme", System.Text.Encoding.UTF8);
                mail.Subject = "Şifre Güncelleme Talebi";
                mail.Body = $"<a target=\"_blank\" href=\"https://localhost:44353{Url.Action("ResetPassword", "Account", new { userId = user.Id, token = HttpUtility.UrlEncode(resetToken) })}\">Yeni şifre talebi için tıklayınız</a>";
                mail.IsBodyHtml = true;
                SmtpClient smp = new SmtpClient();
                smp.Credentials = new NetworkCredential("oguzhanyklmz27@gmail.com", "bayer1977");
                smp.Port = 587;
                smp.Host = "smtp.gmail.com";
                smp.EnableSsl = true;
                smp.Send(mail);

                ViewBag.State = true;
            }
            else
                ViewBag.State = false;

            return View();
            
        }

        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new ResetPasswordViewModel { Token = token };
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var result = await _userManager.ResetPasswordAsync(user, HttpUtility.UrlDecode(resetPasswordViewModel.Token), resetPasswordViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("LogOn", "Account");
            }
            return View();
        }
        public async Task<IActionResult> LogOff()
        {

            await _signInManager.SignOutAsync();
            TempData.Put("message", new AlertMessage()
            {
                Title = "Oturum Kapatıldı.",
                Message = "Hesabınız güvenli bir şekilde kapatıldı.",
                AlertType = "warning"
            });
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> ConfirmEmail( string userId,string token)
        {
            if (userId==null || token==null)
            {
                TempData["Message"] = "Geçersiz Token";
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user!=null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    TempData["Message"] = "Hesabınız Onaylandı ! ";
                    return View();
                }
               
            }
            TempData["Message"] = "Hesabınız Onaylanmadı ! ";

            return View();
        }
    }
}