using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PsychologyCenter.Areas.Manage.Filters;
using PsychologyCenter.DAL;
using PsychologyCenter.Models;

namespace PsychologyCenter.Areas.Manage.Controllers
{
    [Auth]
    public class TimelinesController : Controller
    {
        private PsychologyContext db = new PsychologyContext();

        // GET: Manage/Timelines
        public ActionResult Index()
        {
            return View(db.Timeliness.ToList());
        }
        

        // GET: Manage/Timelines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Timelines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Text,OrderBy")] Timeline timeline)
        {
            if (ModelState.IsValid)
            {
                db.Timeliness.Add(timeline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeline);
        }

        // GET: Manage/Timelines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timeline timeline = db.Timeliness.Find(id);
            if (timeline == null)
            {
                return HttpNotFound();
            }
            return View(timeline);
        }

        // POST: Manage/Timelines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Text,OrderBy")] Timeline timeline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeline);
        }

        // GET: Manage/Timelines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timeline timeline = db.Timeliness.Find(id);
            if (timeline == null)
            {
                return HttpNotFound();
            }
            return View(timeline);
        }

        // POST: Manage/Timelines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Timeline timeline = db.Timeliness.Find(id);
            db.Timeliness.Remove(timeline);
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
