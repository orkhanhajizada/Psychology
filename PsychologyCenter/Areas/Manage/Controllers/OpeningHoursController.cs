using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PsychologyCenter.DAL;
using PsychologyCenter.Models;

namespace PsychologyCenter.Areas.Manage.Controllers
{
    public class OpeningHoursController : Controller
    {
        private PsychologyContext db = new PsychologyContext();

        // GET: Manage/OpeningHours
        public ActionResult Index()
        {
            return View(db.OpeningHours.ToList());
        }
        

        // GET: Manage/OpeningHours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/OpeningHours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Day,OpenHour,OrderBy")] OpeningHour openingHour)
        {
            if (ModelState.IsValid)
            {
                db.OpeningHours.Add(openingHour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(openingHour);
        }

        // GET: Manage/OpeningHours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpeningHour openingHour = db.OpeningHours.Find(id);
            if (openingHour == null)
            {
                return HttpNotFound();
            }
            return View(openingHour);
        }

        // POST: Manage/OpeningHours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Day,OpenHour,OrderBy")] OpeningHour openingHour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(openingHour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(openingHour);
        }

        // GET: Manage/OpeningHours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpeningHour openingHour = db.OpeningHours.Find(id);
            if (openingHour == null)
            {
                return HttpNotFound();
            }
            return View(openingHour);
        }

        // POST: Manage/OpeningHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpeningHour openingHour = db.OpeningHours.Find(id);
            db.OpeningHours.Remove(openingHour);
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
