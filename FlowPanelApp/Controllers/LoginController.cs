using FlowPanelApp.Models;
using FlowPanelApp.Services.AppService;
using FlowPanelApp.Services.UserService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IUserService _userService;
        private readonly IAppService _appService;
        public List<User> users = null;

        public LoginController(IUserService userService, IAppService appService)
        {
            _userService = userService;
            _appService = appService;
        }

        public async Task<IActionResult> Login(string returnUrl = "")
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = GetAppHomeUrl();
            }
            LoginModel loginModel = new LoginModel();
            loginModel.ReturnUrl = returnUrl;
            return View(loginModel);
        }
       

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel, string returnUrl = "")
        {
            returnUrl = NormalizeReturnUrl(returnUrl);        
            var user = await _userService.GetUserByUserNameAndPassword(loginModel.UserName, loginModel.Password);
            if(user != null)
            {
                _appService.HoldUserData(user);
                var claims = new List<Claim>() 
                {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.UserId)),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("DotNetCookie", "Code")
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "Role", user.Role);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = loginModel.RememberLogin
                });
                HttpContext.User = new ClaimsPrincipal(identity);
                return Redirect(returnUrl);            
            }
            else
            {
                ViewBag.Message = "Invalid Credential";
                return View(loginModel);
            }
        }    

        public async Task<IActionResult> CreateUser(User user)
        {                      
            await _userService.AddUser(user);
            ViewBag.Message = "Account created contact with admin to active your account!";
            return RedirectToAction("Login", "Login");              
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
        
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        private string NormalizeReturnUrl(string returnUrl, Func<string> defaultValueBuilder = null)
        {
            if (defaultValueBuilder == null)
            {
                defaultValueBuilder = GetAppHomeUrl;
            }

            if (String.IsNullOrEmpty(returnUrl))
            {
                return defaultValueBuilder();
            }

            if (Url.IsLocalUrl(returnUrl))
            {
                return returnUrl;
            }

            return defaultValueBuilder();
        }
        public string GetAppHomeUrl()
        {
            return Url.Action("Index", "Home");
        }

    }
}
