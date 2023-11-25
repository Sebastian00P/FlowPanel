using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowPanelApp.Models.StudentCalendar
{
    [Table("Lesson")]
    public class Lesson
    {
        [Key]
        public long LessonId { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string NameOfSubject { get; set; }
        public virtual Calendar Calendar { get; set; }
        public long CalendarId { get; set; }
    }
}
