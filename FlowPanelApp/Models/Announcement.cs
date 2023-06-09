using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowPanelApp.Models
{
    public class Announcement
    {
        [Key]
        public long Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public long UserId { get; set; }
    }
}
