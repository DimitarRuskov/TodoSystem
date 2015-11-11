namespace Issues.Web.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using Issues.Models;

    using Issues.Common.Mappings;

    public class IssueDetailsViewModel : IMapFrom<Issue>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Time { get; set; }

        public string Description { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Issue, IssueDetailsViewModel>();
        }
    }
}