namespace Issues.Web.Infrastructure.CacheService
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using Issues.Data;
    using Issues.Web.ViewModels;

    public class MemoryCacheService : BaseCacheService, ICacheService
    {
        private readonly IIssuesData data;

        public MemoryCacheService(IIssuesData data)
        {
            this.data = data;
        }

        public IList<IssueViewModel> Issues
        {
            get
            {
                return this.Get<IList<IssueViewModel>>("Issues", () =>
                    this.data.Issues
                        .All()
                        .Take(6)
                        .Project()
                        .To<IssueViewModel>()
                        .ToList());
            }
        }
    }
}