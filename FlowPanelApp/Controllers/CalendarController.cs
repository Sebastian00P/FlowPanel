using FlowPanelApp.Models;
using FlowPanelApp.Models.StudentCalendar;
using FlowPanelApp.Models.StudentCalendar.CreateLessonViewModel;
using FlowPanelApp.Services.CalendarService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowPanelApp.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICalendarService _calendarService;
        private static long StudentId = 0;
        private static long CalendarId = 0;

        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [Authorize]
        public async Task<IActionResult> Index(long studentId)
        {
            if(studentId != 0)
            {
                StudentId = studentId;
            }
            if (!await _calendarService.CheckIfStudentHasCalendar(StudentId))
            {
                await _calendarService.CreateNewCalendar(new Calendar() { StudentId = studentId});
            }
            var model = await _calendarService.GetCalendar(studentId);
            if(model.CalendarId != 0)
            {
                CalendarId = model.CalendarId;
            }
                    
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {          
            var model = new CreateLessonViewModel()
            {
                CalendarId = CalendarId,
                Courses = await _calendarService.GetCoursesNames(StudentId)
            };
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> CreateLesson(Lesson lesson)
        {
            lesson.CalendarId = CalendarId;
            await _calendarService.CreateNewLesson(lesson);
            return RedirectToAction("Index","Calendar", new { studentId = StudentId });
        }
    }
}
