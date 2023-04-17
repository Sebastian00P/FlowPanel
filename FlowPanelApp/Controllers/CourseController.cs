using FlowPanelApp.Models;
using FlowPanelApp.Services.CourseService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowPanelApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private static long StudentId;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task<IActionResult> Index(long studentId)
        {
            if(studentId != 0)
            {
                StudentId = studentId;
            }
            var model = await _courseService.GetCoursesByStudentId(studentId);
            return View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateCourse(Course course)
        {
            course.StudentId = StudentId;
            await _courseService.CreateCourse(course);
            return RedirectToAction("Index", new { studentId = course.StudentId });
        }

        [Authorize]
        public async Task<IActionResult> Edit(long courseId)
        {
            var model = await _courseService.GetCourseById(courseId);
            return View(model);
        }

        public async Task<IActionResult> EditCourse(Course course)
        {
            course.StudentId = StudentId;
            await _courseService.CreateCourse(course);
            return RedirectToAction("Index", new { studentId = course.StudentId });
        }
    }
}
