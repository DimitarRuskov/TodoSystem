namespace Issues.Web.ViewModels
{
    using Issues.Models;

    using Issues.Common.Mappings;

    public class IssueViewModel : IMapFrom<Issue>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Time { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public User CreatedBy { get; set; }

        public User AssignedTo { get; set; }
    }
}
