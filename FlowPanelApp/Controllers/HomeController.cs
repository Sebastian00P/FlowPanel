using FlowPanelApp.Models;
using FlowPanelApp.Services.Announcement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnnouncementService _announcementService;

        public HomeController(ILogger<HomeController> logger, IAnnouncementService announcementService)
        {
            _logger = logger;
            _announcementService = announcementService;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {   
            var model = await _announcementService.GetAll();
            return View(model);
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> CreateAnnouncement(Announcement announcement)
        {
            await _announcementService.CreateAnnouncement(announcement);
            return RedirectToAction("Index");
        }
    }
}
