using FlowPanelApp.Models;
using FlowPanelApp.Services.StudentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlowPanelApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private static long ClassId { get; set; }
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [Authorize]
        public async Task<IActionResult> Index(long classId)
        {
            if(classId != 0) 
            {
                ClassId = classId;
            }     
            var model = await _studentService.GetStudentsByClassId(ClassId);
            return View(model);
        }

        [Authorize]
        public IActionResult Create()
        {          
            return View();
        }

        [Authorize]
        public async Task<IActionResult> CreateNewStudent(Student student)
        {
            student.ClassId = ClassId;
            await _studentService.CreateStudent(student);
            return RedirectToAction("Index", new { classId = student.ClassId });
        }

        [Authorize]
        public async Task<IActionResult> Edit(long studentId)
        {
            var model = await _studentService.GetStudentById(studentId);
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> EditStudent(Student student)
        {
            student.ClassId = ClassId;
            await _studentService.EditStudent(student);
            return RedirectToAction("Index", new { classId = student.ClassId });
        }
        public IActionResult StudentDetails(long studentId)
        {
            return RedirectToAction("Index", "Course", new { StudentId = studentId });
        }
    }
}
