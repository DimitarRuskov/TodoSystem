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

namespace Bookmarks.Web.Controllers
{
    public class TicketsController : Controller
    {
        private IssuesDbContext db = new IssuesDbContext();

        // GET: Tickets
        public ActionResult Index()
        {
            var issues = db.Issues.Include(i => i.AssignedTo).Include(i => i.CreatedBy);
            return View(issues.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.AssignedToId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Time,CreatedById,AssignedToId,Description,Status,CreatedAt,UpdatedAt")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                db.Issues.Add(issue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssignedToId = new SelectList(db.Users, "Id", "FirstName", issue.AssignedToId);
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "FirstName", issue.CreatedById);
            return View(issue);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssignedToId = new SelectList(db.Users, "Id", "FirstName", issue.AssignedToId);
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "FirstName", issue.CreatedById);
            return View(issue);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Time,CreatedById,AssignedToId,Description,Status,CreatedAt,UpdatedAt")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssignedToId = new SelectList(db.Users, "Id", "FirstName", issue.AssignedToId);
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "FirstName", issue.CreatedById);
            return View(issue);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Issue issue = db.Issues.Find(id);
            db.Issues.Remove(issue);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
