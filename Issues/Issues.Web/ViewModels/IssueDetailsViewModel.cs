namespace Issues.Web.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using Issues.Models;

    using Issues.Common.Mappings;
    using System;

    public class IssueDetailsViewModel : IMapFrom<Issue>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Time { get; set; }

        public string Description { get; set; }

        public User CreatedBy { get; set; }
        public User AssignedTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Issue, IssueDetailsViewModel>();
        }
    }
}