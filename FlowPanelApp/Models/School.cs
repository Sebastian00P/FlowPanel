using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Models
{
    [Table("School")]
    public class School
    {
        [Key]
        public long SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string Address { get; set; }
        public byte[] Logo { get; set; }        
        public ICollection<ClassModel> Classes { get; set; }
    }
}
