using FlowPanelApp.Services.ClassService;
using FlowPanelApp.Services.SchoolService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowPanelApp.Controllers
{
    public class ClassesController : Controller
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService) 
        {
            _classService = classService;
        }
        public async Task<IActionResult> Index(long schoolID)
        {
            var model = await _classService.GetClassesBySchoolId(schoolID);
            return View(model);
        }
    }
}
