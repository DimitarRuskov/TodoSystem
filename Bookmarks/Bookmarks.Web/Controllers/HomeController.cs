namespace Issues.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Issues.Data;
    using Issues.Web.Infrastructure.CacheService;
    using Issues.Web.ViewModels;

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
            var viewModel = new HomeViewModel { Issues = this.cacheService.Issues };
            return View(viewModel);
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