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
    public class GaleryCategoriesController : Controller
    {
        private PsychologyContext db = new PsychologyContext();

        // GET: Manage/GaleryCategories
        public ActionResult Index()
        {
            return View(db.GaleryCategories.ToList());
        }
        

        // GET: Manage/GaleryCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/GaleryCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] GaleryCategory galeryCategory)
        {
            if (ModelState.IsValid)
            {
                db.GaleryCategories.Add(galeryCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(galeryCategory);
        }

        // GET: Manage/GaleryCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GaleryCategory galeryCategory = db.GaleryCategories.Find(id);
            if (galeryCategory == null)
            {
                return HttpNotFound();
            }
            return View(galeryCategory);
        }

        // POST: Manage/GaleryCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] GaleryCategory galeryCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galeryCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(galeryCategory);
        }

        // GET: Manage/GaleryCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GaleryCategory galeryCategory = db.GaleryCategories.Find(id);
            if (galeryCategory == null)
            {
                return HttpNotFound();
            }
            return View(galeryCategory);
        }

        // POST: Manage/GaleryCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GaleryCategory galeryCategory = db.GaleryCategories.Find(id);
            db.GaleryCategories.Remove(galeryCategory);
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
