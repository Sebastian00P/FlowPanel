using FlowPanelApp.Models;
using FlowPanelApp.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            var model = await _userService.GetAll();
            return View(model);
        }
        [Authorize]
        public IActionResult CreateUser()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Create(User user)
        {
            await _userService.AddUser(user);
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<IActionResult> Delete(long userId)
        {
            var user = await _userService.GetUserById(userId);
            await _userService.DeleteUser(user);
            return RedirectToAction("Index");
        }
    }
}
