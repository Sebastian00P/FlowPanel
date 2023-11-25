using FlowPanelApp.Context;
using FlowPanelApp.Models.StudentCalendar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.CalendarService
{
    public class CalendarService : ICalendarService
    {
        private readonly FlowContext _flowContext;
        public CalendarService(FlowContext flowContext)
        {
            _flowContext = flowContext;
        }
        public async Task<Calendar> GetCalendar(long studentId)
        {
            var calendar = await _flowContext.Calendars.Include(x => x.Lessons).FirstOrDefaultAsync(x => x.StudentId == studentId);
            return calendar;
        }
        public async Task<bool> CheckIfStudentHasCalendar(long studentId)
        {
            var calendar = await _flowContext.Calendars.FirstOrDefaultAsync(x => x.StudentId == studentId);
            if(calendar == null) 
            { 
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task CreateNewCalendar(Calendar calendar)
        {
            try
            {
                await _flowContext.Calendars.AddAsync(calendar);
                await _flowContext.SaveChangesAsync();
            }
            catch(Exception ex)
            { 
             
            }
        }

        public async Task CreateNewLesson(Lesson lesson)
        {
            try
            {
                await _flowContext.Lessons.AddAsync(lesson);
                await _flowContext.SaveChangesAsync();
            }
            catch (Exception ex) 
            { 
            }
        }

        public async Task<List<string>> GetCoursesNames(long studentId)
        {
            var items =  await _flowContext.Courses.Where(x => x.StudentId == studentId).ToListAsync();
            var courses = items.Select(x => x.CourseName).ToList();
            return courses;
        }
        public async Task<Lesson> GetLessonById(long lessonId)
        {
            return await _flowContext.Lessons.FirstOrDefaultAsync(x => x.LessonId == lessonId);
        }

        public async Task DeleteLesson(long lessonId)
        {
            try
            {
                var lesson = await GetLessonById(lessonId);
                _flowContext.Lessons.Remove(lesson);
                await _flowContext.SaveChangesAsync();
            }
            catch(Exception ex)
            { 
            
            }
        }
    }
}
