using System.Collections.Generic;

namespace FlowPanelApp.Models.StudentCalendar.CreateLessonViewModel
{
    public class CreateLessonViewModel
    {
        public long CalendarId { get; set; }
        public List<string> Courses { get; set; }
        public Lesson Lesson { get; set; }
    }
}
