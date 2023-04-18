using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowPanelApp.Models
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        public long TeacherId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Pesel { get; set; }
        public int Age { get; set; }
        public byte[] Picture { get; set; }
        [ForeignKey(nameof(ClassId))]
        public virtual ClassModel ClassModel { get; set; }
        public long ClassId { get; set; }
    }
}
