
namespace TodoSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Content { get; set; }

        [Required]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int TaskId { get; set; }

        public virtual IssueTask Task { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
