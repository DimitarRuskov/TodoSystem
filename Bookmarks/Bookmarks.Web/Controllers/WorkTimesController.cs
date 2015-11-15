using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Issues.Data;
using Issues.Models;
using Microsoft.AspNet.Identity;
using System;

namespace Issues.Web.Controllers
{
    public class WorkTimesController : Controller
    {
        private IssuesDbContext db = new IssuesDbContext();

        // GET: WorkTimes
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            return View(db.WorkTimes.Where(w => w.UserId == userId).ToList());
        }

        // GET: WorkTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTime workTime = db.WorkTimes.Find(id);
            if (workTime == null)
            {
                return HttpNotFound();
            }
            return View(workTime);
        }

        // GET: WorkTimes/Create
        public ActionResult Create()
        {
            ViewBag.IssueId = new SelectList(db.Issues, "Id", "Title");
            return View();
        }

        // POST: WorkTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,IssueId,Time,CreatedAt")] WorkTime workTime)
        {
            workTime.UserId = this.User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.WorkTimes.Add(workTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IssueId = new SelectList(db.Issues, "Id", "Title", workTime.IssueId);
            return View(workTime);
        }

        // GET: WorkTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTime workTime = db.WorkTimes.Find(id);
            if (workTime == null)
            {
                return HttpNotFound();
            }
            return View(workTime);
        }

        // POST: WorkTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,IssueID,LoggedHours,DateLogged")] WorkTime workTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workTime);
        }

        // GET: WorkTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTime workTime = db.WorkTimes.Find(id);
            if (workTime == null)
            {
                return HttpNotFound();
            }
            return View(workTime);
        }

        // POST: WorkTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkTime workTime = db.WorkTimes.Find(id);
            db.WorkTimes.Remove(workTime);
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
