using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Issues.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        //[ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        //[ForeignKey("Issue")]
        public int IssueId { get; set; }
        public virtual Issue Issue{ get; set; }
    }
}
