﻿using FlowPanelApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlowPanelApp.Controllers
{
    public class LoginController : Controller
    {

        public List<User> users = null;

        public LoginController()
        {
            users = new List<User>();
            users.Add(new User()
            {
                UserId = 1,
                UserName = "admin",
                Password = "123qwe",
                Role = "Admin",
                Email = "pociask@onet.com.pl",
                IsActive = true
            });
            users.Add(new User()
            {
                UserId = 2,
                UserName = "user",
                Password = "qwerty",
                Role = "User",
                Email = "test@onet.com.pl",
                IsActive = true
            });

        }

        public IActionResult Login(string ReturnUrl = "/Home/Index")
        {
            LoginModel loginModel = new LoginModel();
            loginModel.ReturnUrl = ReturnUrl;
            return View(loginModel);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = users.Where(x => x.UserName == loginModel.UserName && x.Password == loginModel.Password).FirstOrDefault();
            if(user != null)
            {
                var claims = new List<Claim>() 
                {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.UserId)),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("DotNetCookie", "Code")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = loginModel.RememberLogin
                });
                HttpContext.User = new ClaimsPrincipal(identity);

                return RedirectToAction("AuthorizedView");
            }
            else
            {
                ViewBag.Message = "Invalid Credential";
                return View(loginModel);
            }
        }

        public async Task<IActionResult> AuthorizedView()
        {

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
        

        public IActionResult CreateNewUser()
        {
            return View();
        }
    }
}
