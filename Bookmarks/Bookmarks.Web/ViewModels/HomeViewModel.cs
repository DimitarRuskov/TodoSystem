namespace Issues.Web.ViewModels
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IEnumerable<IssueViewModel> Issues { get; set; }
    }
}