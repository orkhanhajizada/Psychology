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
    public class SlidersController : Controller
    {
        private PsychologyContext db = new PsychologyContext();

        // GET: Manage/Sliders
        public ActionResult Index()
        {
            return View(db.Sliders.ToList());
        }

       

        // GET: Manage/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title1,Title2,Text,Photo,OrderBy")] Slider slider, HttpPostedFileBase Photo)
        {
            if (Photo == null)
            {
                ModelState.AddModelError("Photo", "Please Select file");
                ModelState.AddModelError("Title Photo", "Please Select file");
            }
            else
            {
                slider.Photo = FileManager.Upload(Photo);

            }
            if (ModelState.IsValid)
            {
                db.Sliders.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: Manage/Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Manage/Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title1,Title2,Text,Photo,OrderBy")] Slider slider, HttpPostedFileBase Photo)
        {
            db.Entry(slider).State = EntityState.Modified;

            if (Photo == null)
            {
                db.Entry(slider).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                FileManager.Delete(slider.Photo);

                slider.Photo = FileManager.Upload(Photo);
            }
            if (ModelState.IsValid)
            {
                db.Entry(slider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Manage/Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Manage/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Sliders.Find(id);
            db.Sliders.Remove(slider);
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
