namespace Issues.Web.Infrastructure.CacheService
{
    using System.Collections.Generic;

    using Issues.Web.ViewModels;

    public interface ICacheService
    {
        IList<IssueViewModel> Issues { get; }
    }
}
