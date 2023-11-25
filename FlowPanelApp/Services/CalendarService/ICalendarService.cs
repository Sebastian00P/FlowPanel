using FlowPanelApp.Models.StudentCalendar;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.CalendarService
{
    public interface ICalendarService
    {
        Task<Calendar> GetCalendar(long studentId);
        Task CreateNewCalendar(Calendar calendar);
        Task CreateNewLesson(Lesson lesson);
        Task<bool> CheckIfStudentHasCalendar(long studentId);
        Task<List<string>> GetCoursesNames(long studentId);
        Task<Lesson> GetLessonById(long lessonId);
        Task DeleteLesson(long lessonId);
        Task UpdateLesson(Lesson lesson);
    }
}