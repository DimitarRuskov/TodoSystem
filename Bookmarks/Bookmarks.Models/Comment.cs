using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Issues.Models
{
    public class Comment
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        //[ForeignKey("User")]
        [Display(Name = "User ID")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        //[ForeignKey("Issue")]
        [Display(Name ="Ticket ID")]
        public int IssueId { get; set; }
        public virtual Issue Issue{ get; set; }

        [Display(Name = "Created Date")]
        public DateTime DateCreated { get; set; }
    }
}
