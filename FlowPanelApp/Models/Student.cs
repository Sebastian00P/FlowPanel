using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public long StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Pesel { get; set; }
        public string Address { get; set; }
        public ICollection<Course> Courses { get; set; }
        public virtual ClassModel Class { get; set; }
        public long ClassId { get; set; }
    }
}
