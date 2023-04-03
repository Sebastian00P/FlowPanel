using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public virtual Student Student { get; set; }
        public long StudentId { get; set; }
        public ICollection<Grade> Grades { get; set; }

    }
}
