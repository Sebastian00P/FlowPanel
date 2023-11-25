using FlowPanelApp.Models;
using FlowPanelApp.Models.StudentCalendar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FlowPanelApp.Controllers
{
    public class CalendarController : Controller
    {
        private static long StudentId = 0;
        private static long CalendarId = 0;
        [Authorize]
        public IActionResult Index(long studentId)
        {
            if (studentId != 0)
            {
                StudentId = studentId;
            }
            var lessons = new List<Lesson>();
            var lesson = new Lesson()
            {
                CalendarId = 1,
                Day = DayOfWeek.Monday,
                LessonId = 1,
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(8, 45, 0),
                NameOfSubject = "Seminarium"
            };
            lessons.Add(lesson);
            var model = new Calendar()
            {
                CalendarId = 1,
                StudentId = 1,
                Lessons = lessons
            };
            
            return View(model);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
    }
}
