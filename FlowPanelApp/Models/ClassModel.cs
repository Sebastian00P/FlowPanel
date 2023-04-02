using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Models
{
    [Table("Class")]
    public class ClassModel
    {
        [Key]
        public long ClassId { get; set; }
        public string ClassName { get; set; }
    }
}
