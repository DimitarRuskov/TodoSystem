namespace Issues.Web.Controllers
{
    using System.Web.Mvc;

    using Issues.Data;

    [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        protected AdminController(IIssuesData data)
            : base(data)
        {
        }
    }
}