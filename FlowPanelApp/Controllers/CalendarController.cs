using FlowPanelApp.Models;
using FlowPanelApp.Models.StudentCalendar;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FlowPanelApp.Controllers
{
    public class CalendarController : Controller
    {
        private static long StudentId = 0;
        public IActionResult Index(long studentId)
        {
            if (studentId != 0)
            {
                StudentId = studentId;
            }
            var model = new Calendar();
            return PartialView();
        }
    }
}
