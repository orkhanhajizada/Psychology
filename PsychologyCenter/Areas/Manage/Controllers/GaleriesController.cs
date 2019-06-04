using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PsychologyCenter.Areas.Manage.Helpers;
using PsychologyCenter.DAL;
using PsychologyCenter.Models;

namespace PsychologyCenter.Areas.Manage.Controllers
{
    public class GaleriesController : Controller
    {
        private PsychologyContext db = new PsychologyContext();

        // GET: Manage/Galeries
        public ActionResult Index()
        {
            var galeries = db.Galeries.Include(g => g.GaleryCategory);
            return View(galeries.ToList());
        }
        

        // GET: Manage/Galeries/Create
        public ActionResult Create()
        {
            ViewBag.GaleryCategoryId = new SelectList(db.GaleryCategories, "Id", "Name");
            return View();
        }

        // POST: Manage/Galeries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Photo,BigPhoto,GaleryCategoryId")] Galery galery,  HttpPostedFileBase Photo, HttpPostedFileBase BigPhoto)
        {
            if (Photo == null)
            {
                ModelState.AddModelError("Photo", "Please Select file");
            }
            if (BigPhoto == null)
            {
                ModelState.AddModelError("Title Photo", "Please Select file");
            }
            else
            {
                galery.Photo = FileManager.Upload(Photo);
                galery.BigPhoto = FileManager.Upload(BigPhoto);
            }

            if (ModelState.IsValid)
            {
                db.Galeries.Add(galery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GaleryCategoryId = new SelectList(db.GaleryCategories, "Id", "Name", galery.GaleryCategoryId);
            return View(galery);
        }

        // GET: Manage/Galeries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galery galery = db.Galeries.Find(id);
            if (galery == null)
            {
                return HttpNotFound();
            }
            ViewBag.GaleryCategoryId = new SelectList(db.GaleryCategories, "Id", "Name", galery.GaleryCategoryId);
            return View(galery);
        }

        // POST: Manage/Galeries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Photo,BigPhoto,GaleryCategoryId")] Galery galery, HttpPostedFileBase Photo, HttpPostedFileBase BigPhoto)
        {
            db.Entry(galery).State = EntityState.Modified;

            if (Photo == null)
            {
                db.Entry(galery).Property(a => a.Photo).IsModified = false;
            }
            if (BigPhoto == null)
            {
                db.Entry(galery).Property(b => b.BigPhoto).IsModified = false;
            }
            else
            {
                FileManager.Delete(galery.Photo);
                FileManager.Delete(galery.BigPhoto);

                galery.Photo = FileManager.Upload(Photo);
                galery.BigPhoto = FileManager.Upload(BigPhoto);
            }

            if (ModelState.IsValid)
            {
                db.Entry(galery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GaleryCategoryId = new SelectList(db.GaleryCategories, "Id", "Name", galery.GaleryCategoryId);
            return View(galery);
        }

        // GET: Manage/Galeries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galery galery = db.Galeries.Find(id);
            if (galery == null)
            {
                return HttpNotFound();
            }
            return View(galery);
        }

        // POST: Manage/Galeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Galery galery = db.Galeries.Find(id);
            db.Galeries.Remove(galery);
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
