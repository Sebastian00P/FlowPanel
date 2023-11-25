using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowPanelApp.Models.StudentCalendar
{
    [Table("Calendar")]
    public class Calendar
    {
        [Key]
        public long CalendarId { get; set; }
        public long StudentId { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
