namespace Issues.Web.ViewModels
{
    using Issues.Models;
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IEnumerable<Issue> CreatedIssues { get; set; }

        public IEnumerable<Issue> AssignedIssues { get; set; }
    }
}