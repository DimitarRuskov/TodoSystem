using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Issues.Models
{
    public class WorkTime
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "User ID")]
        public int UserID { get; set; }
        [Display(Name = "Issue ID")]
        public int IssueID { get; set; }
        [Display(Name = "Work Hours")]
        public double LoggedHours { get; set; }
        [Display(Name = "Work Days" )]
        public DateTime DateLogged { get; set; }
    }
}
