namespace TodoSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Task
    {
        private ICollection<Comment> comments;

        public Task()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public float Assessment { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        public int AssignedToId { get; set; }

        public virtual User AssignedTo { get; set; }

        [Required]
        public int CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual ICollection<Comment> Comments {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
