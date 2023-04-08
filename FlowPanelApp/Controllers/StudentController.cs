using FlowPanelApp.Services.StudentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowPanelApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [Authorize]
        public async Task<IActionResult> Index(long ClassId)
        {
            var model = await _studentService.GetStudentsByClassId(ClassId);
            return View(model);
        }
    }
}
