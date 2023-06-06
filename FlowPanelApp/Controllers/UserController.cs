using FlowPanelApp.Models;
using FlowPanelApp.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;       
        public UserController(IUserService userService)
        {
            _userService = userService;                 
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.User.Identities.Select(x => x.RoleClaimType == "Admin").FirstOrDefault())
            {
                var model = await _userService.GetAll();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Authorize]
        public IActionResult CreateUser()
        {
            if (HttpContext.User.Identities.Select(x => x.RoleClaimType == "Admin").FirstOrDefault())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Authorize]
        public async Task<IActionResult> Create(User user)
        {
            if (HttpContext.User.Identities.Select(x => x.RoleClaimType == "Admin").FirstOrDefault())
            {
                await _userService.AddUser(user);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Authorize]
        public async Task<IActionResult> Delete(long userId)
        {
            if (HttpContext.User.Identities.Select(x => x.RoleClaimType == "Admin").FirstOrDefault())
            {
                var user = await _userService.GetUserById(userId);
                await _userService.DeleteUser(user);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Authorize]
        public async Task<IActionResult> EditUser(long userId)
        {
            if (HttpContext.User.Identities.Select(x => x.RoleClaimType == "Admin").FirstOrDefault())
            {
                var model = await _userService.GetUserById(userId);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Authorize]
        public async Task<IActionResult> Edit(User user)
        {
            if (HttpContext.User.Identities.Select(x => x.RoleClaimType == "Admin").FirstOrDefault())
            {
                await _userService.EditUser(user);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
