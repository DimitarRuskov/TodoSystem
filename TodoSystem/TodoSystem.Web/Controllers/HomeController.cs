using System.Web.Mvc;
using TodoSystem.Data;

namespace TodoSystem.Web.Controllers
{
    public abstract class HomeController : BaseController
    {

        //public  HomeController(ApplicationDbContext data) : base(data)
        //{
            
        //}

        public ActionResult Index()
        {
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