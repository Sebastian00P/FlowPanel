using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Models
{
    [Table("Grade")]
    public class Grade
    {
        [Key]
        public long GradeId { get; set; }
        public string GradeName { get; set; }
        public double GradeValue { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? AddDate { get; set; }
        public virtual Course Course { get; set; }
        public long CourseId { get; set; }
    }
}
