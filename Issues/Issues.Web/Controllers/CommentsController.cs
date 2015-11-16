using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Issues.Data;
using Issues.Models;
using Microsoft.AspNet.Identity;

namespace Issues.Web.Controllers
{
    public class CommentsController : BaseController
    {
        public CommentsController(IIssuesData data)
            : base(data)
        {
        }

        public ActionResult Comment(int id, string content)
        {
            var issue = this.Data.Issues.All()
                .FirstOrDefault(b => b.Id == id);
            string userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.All()
                .FirstOrDefault(u => u.Id == userId);
            var date = DateTime.Now;

            issue.Comments.Add(new Comment()
            {
                Content = content,
                UserId = userId,
                CreatedAt = date
            });

            this.Data.SaveChanges();

            return this.Json(new { Content = content, User = user.UserName, CreatedAt = date }, JsonRequestBehavior.AllowGet);
        }
    }
}
