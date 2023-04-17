using FlowPanelApp.Models;
using FlowPanelApp.Services.GradeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowPanelApp.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;
        private static long CourseId = 0;
        public GradeController (IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        [Authorize]
        public async Task<IActionResult> Index(long courseId)
        {
            if(courseId != 0) 
            {
                CourseId = courseId;
            }
            var model = await _gradeService.GetGradesByCourseId(CourseId);
            return View(model);
        }
        [Authorize]
        public IActionResult Create()
        {                     
            return View();
        }

        [Authorize]
        public async Task<IActionResult> CreateGrade(Grade grade)
        {
            grade.CourseId = CourseId;
            await _gradeService.CreateNewGrade(grade);
            return RedirectToAction("Index", new { courseId = grade.CourseId });
        }

        [Authorize]
        public async Task<IActionResult> Edit(long gradeId)
        {
            var model = await _gradeService.GetGradeById(gradeId);
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> EditGrade(Grade grade)
        {
            grade.CourseId = CourseId;
            await _gradeService.EditGrade(grade);
            return RedirectToAction("Index", new { courseId = grade.CourseId });
        }
    }
}
