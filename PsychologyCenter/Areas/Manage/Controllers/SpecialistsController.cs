using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PsychologyCenter.Areas.Manage.Filters;
using PsychologyCenter.Areas.Manage.Helpers;
using PsychologyCenter.DAL;
using PsychologyCenter.Models;

namespace PsychologyCenter.Areas.Manage.Controllers
{
    [Auth]
    public class SpecialistsController : Controller
    {
        private PsychologyContext db = new PsychologyContext();

        // GET: Manage/Specialists
        public ActionResult Index()
        {
            return View(db.Specialists.ToList());
        }

       

        // GET: Manage/Specialists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Specialists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Text,Photo,SpecItem1,SpecItem2,SpecItem3,SpecItem4,SpecItem5,SpecItem6,Icon,IsActive")] Specialist specialist, HttpPostedFileBase Photo)
        {
            if (Photo == null)
            {
                ModelState.AddModelError("Photo", "Please Select file");
                ModelState.AddModelError("Title Photo", "Please Select file");
            }
            else
            {
                specialist.Photo = FileManager.Upload(Photo);

            }
            if (ModelState.IsValid)
            {
                db.Specialists.Add(specialist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specialist);
        }

        // GET: Manage/Specialists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialist specialist = db.Specialists.Find(id);
            if (specialist == null)
            {
                return HttpNotFound();
            }
            return View(specialist);
        }

        // POST: Manage/Specialists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Text,Photo,SpecItem1,SpecItem2,SpecItem3,SpecItem4,SpecItem5,SpecItem6,Icon,IsActive")] Specialist specialist, HttpPostedFileBase Photo)
        {
            db.Entry(specialist).State = EntityState.Modified;

            if (Photo == null)
            {
                db.Entry(specialist).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                FileManager.Delete(specialist.Photo);

                specialist.Photo = FileManager.Upload(Photo);
            }
            if (ModelState.IsValid)
            {
                db.Entry(specialist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialist);
        }

        // GET: Manage/Specialists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialist specialist = db.Specialists.Find(id);
            if (specialist == null)
            {
                return HttpNotFound();
            }
            return View(specialist);
        }

        // POST: Manage/Specialists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Specialist specialist = db.Specialists.Find(id);
            db.Specialists.Remove(specialist);
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
