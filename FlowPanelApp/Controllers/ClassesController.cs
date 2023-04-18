using FlowPanelApp.Models;
using FlowPanelApp.Services.ClassService;
using FlowPanelApp.Services.SchoolService;
using FlowPanelApp.Services.TeacherService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowPanelApp.Controllers
{
    public class ClassesController : Controller
    {
        private static long SchoolId = 0;
        private readonly IClassService _classService;
        private readonly ISchoolService _schoolService;
        private readonly ITeacherService _teacherService;

        public ClassesController(IClassService classService, ISchoolService schoolService, ITeacherService teacherService) 
        {
            _classService = classService;
            _schoolService = schoolService;
            _teacherService = teacherService;
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
                item.Teacher = await _teacherService.GetTeacherByClassId(item.ClassId);
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
            classModel.SchoolId = SchoolId;
            await _classService.EditClass(classModel);
            return RedirectToAction("Index", "Classes", new { schoolId = classModel.SchoolId });
        }

        [Authorize]
        public IActionResult CreateTeacher()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> TeacherDetails(long classId)
        {
            var model = await _teacherService.GetTeacherByClassId(classId);
            return View(model);
        }
    }
}
