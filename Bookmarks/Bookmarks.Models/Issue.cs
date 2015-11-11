namespace Issues.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Issue
    {
        private ICollection<Comment> comments;

        public Issue()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public double Time { get; set; }
        //TODO: validate users
        [ForeignKey("CreatedBy")]
        public string CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }

        [ForeignKey("AssignedTo")]
        public string AssignedToId { get; set; }
        public virtual User AssignedTo { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
