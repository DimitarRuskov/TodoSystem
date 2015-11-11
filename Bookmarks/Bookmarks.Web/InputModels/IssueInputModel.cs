namespace Issues.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using Issues.Models;

    using Issues.Common.Mappings;
    using System;

    public class IssueInputModel : IMapTo<Issue>
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "The {0} is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The {0} should be between {2} and {1}.")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "The {0} is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The {0} should be between {2} and {1}.")]
        public string Description { get; set; }

        [Display(Name = "Assessment")]
        [Required(ErrorMessage = "The {0} is required.")]
        public double Time { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "The {0} is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The {0} should be between {2} and {1}.")]
        public string Status { get; set; }
    }
}