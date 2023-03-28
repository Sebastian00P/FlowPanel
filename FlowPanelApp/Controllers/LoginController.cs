using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TryAuthUser(string username, string password)
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateNewUser()
        {
            return View();
        }
    }
}
