namespace Issues.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Issues.Common.SystemMessages;
    using Issues.Data;
    using Issues.Models;
    using Issues.Web.InputModels;
    using Issues.Web.ViewModels;

    using Microsoft.AspNet.Identity;

    using PagedList;
    using System;

    [Authorize]
    public class IssuesController : BaseController
    {
        public IssuesController(IIssuesData data)
            : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var issues = this.Data.Issues
                .All()
                .OrderBy(x => x.Title)
                .Project()
                .To<IssueViewModel>()
                .ToPagedList(page ?? 1, 6);
            return View(issues);
        }

        public ActionResult Details(int id)
        {
            var issue = this.Data.Issues
                .All()
                .Where(x => x.Id == id)
                .Project()
                .To<IssueDetailsViewModel>()
                .FirstOrDefault();
            return this.View(issue);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IssueInputModel model)
        {
            if (model != null & this.ModelState.IsValid)
            {
                var issue = Mapper.Map<Issue>(model);
                issue.CreatedAt = DateTime.Now;
                issue.CreatedById = this.User.Identity.GetUserId();
                issue.AssignedToId = this.User.Identity.GetUserId();
                this.Data.Issues.Add(issue);
                this.Data.SaveChanges();

                this.AddSystemMessage(string.Format("Issue {0} added.", issue.Title), SystemMessageType.Success);
                return this.RedirectToAction("Details", new { id = issue.Id });
            }
         
            return this.View(model);
        }
    }
}