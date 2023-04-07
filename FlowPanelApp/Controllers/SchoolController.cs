using FlowPanelApp.Models;
using FlowPanelApp.Services.SchoolService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FlowPanelApp.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var model = await _schoolService.GetAll();                 
            return View(model);
        }

        [Authorize]
        public IActionResult CreateSchool()
        {
            return View();
        }
        public async Task<IActionResult> Create(School school)
        {
            try
            {
                await _schoolService.CreateSchool(school);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction("Index");
            }        
        }
        [Authorize]
        public IActionResult EditSchool(long SchoolId)
        {
            var model = _schoolService.GetSchoolById(SchoolId);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSchool(School school, IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        byte[] bytes = memoryStream.ToArray();

                        school.Logo = bytes;
                    }
                }
                await _schoolService.UpdateSchool(school);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult SchoolDetails(long schoolId)
        {
            return RedirectToAction("Index", "Classes", new {schoolID = schoolId});
        }
    }
}
