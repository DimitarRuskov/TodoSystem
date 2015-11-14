namespace Issues.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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

        [Display(Name = "Spend Time")]
        public double Time { get; set; }

        //TODO: validate users

        [Display(Name = "Created By")]
        [ForeignKey("CreatedBy")]
        public string CreatedById { get; set; }

        [Display(Name = "Created By")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("AssignedTo")]
        [Display(Name = "Assigned To")]
        public string AssignedToId { get; set; }

        [Display(Name = "Assigned To")]
        public virtual User AssignedTo { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Ticket Status")]
        public string Status { get; set; }

        //[DefaultValue(PriorityType.Open)]
        //public PriorityType Status { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
