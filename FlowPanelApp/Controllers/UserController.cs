using FlowPanelApp.Services.UserService;
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
        public async Task<IActionResult> Index()
        {
            var model = await _userService.GetAll();
            return View(model);
        }
    }
}
