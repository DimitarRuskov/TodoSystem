namespace Issues.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Issues.Data;
    using Issues.Web.Infrastructure.CacheService;
    using Issues.Web.ViewModels;
    using Microsoft.AspNet.Identity;

    public class HomeController : BaseController
    {
        private ICacheService cacheService;

        public HomeController(IIssuesData data, ICacheService cacheService)
            : base(data)
        {
            this.cacheService = cacheService;
        }

        public ActionResult Index()
        {
            if(this.User.Identity.IsAuthenticated)
            {
                var userId = this.User.Identity.GetUserId();
                var createdIssues = this.Data.Issues.All().Where(i => i.CreatedById == userId).AsEnumerable();
                var assignedIssues = this.Data.Issues.All().Where(i => i.AssignedToId == userId).AsEnumerable();
                var viewModel = new HomeViewModel { CreatedIssues = createdIssues, AssignedIssues = assignedIssues };
                return View(viewModel);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}