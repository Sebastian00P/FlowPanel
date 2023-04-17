using FlowPanelApp.Models;
using FlowPanelApp.Services.ClassService;
using FlowPanelApp.Services.SchoolService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowPanelApp.Controllers
{
    public class ClassesController : Controller
    {
        private static long SchoolId { get; set; }
        private readonly IClassService _classService;
        private readonly ISchoolService _schoolService;


        public ClassesController(IClassService classService, ISchoolService schoolService) 
        {
            _classService = classService;
            _schoolService = schoolService;
        }
        [Authorize]
        public async Task<IActionResult> Index(long schoolID)
        {
            if(schoolID != 0)
            {
                SchoolId = schoolID;
            }        
            var school = _schoolService.GetSchoolById(SchoolId);
            var model = await _classService.GetClassesBySchoolId(SchoolId);
            foreach (var item in model)
            {
                item.school = school;
            }
            return View(model);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateClass(ClassModel Class)
        {
            Class.SchoolId = SchoolId;
            await _classService.CreateClass(Class);
            return RedirectToAction("Index", new { schoolID = Class.SchoolId});
        }

        public IActionResult ClassDetails(long ClassId) 
        {
            return RedirectToAction("Index", "Student", new { ClassId = ClassId });
        }

        [Authorize]
        public async Task<IActionResult> Edit(long classId)
        {
            var model = await _classService.GetClassById(classId);
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> EditClass(ClassModel classModel)
        {
            await _classService.EditClass(classModel);
            return RedirectToAction("Index", "Student", new { ClassId = classModel.ClassId });
        }
    }
}
