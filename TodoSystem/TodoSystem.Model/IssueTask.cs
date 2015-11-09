namespace TodoSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class IssueTask
    {
        private ICollection<Comment> comments;

        public IssueTask()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int ID { get; set; }

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

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
        //Add Date Created and Date Modified to Task
        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public IssueStatus Status { get; set; }

        public enum IssueStatus
        {
            Pending,
            Done
        }
    }
}
