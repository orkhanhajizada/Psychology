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
    public class SettingsController : Controller
    {
        private PsychologyContext db = new PsychologyContext();

        // GET: Manage/Settings
        public ActionResult Index()
        {
            return View(db.Settings.ToList());
        }

  

        //// GET: Manage/Settings/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Manage/Settings/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Photo,Phone,Email,Adress,Facebook,Instagram,Youtube")] Setting setting)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Settings.Add(setting);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(setting);
        //}

        // GET: Manage/Settings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: Manage/Settings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Photo,Phone,Email,Adress,Facebook,Instagram,Youtube")] Setting setting,HttpPostedFileBase Photo)
        {
            db.Entry(setting).State = EntityState.Modified;

            if (Photo == null)
            {
                db.Entry(setting).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                FileManager.Delete(setting.Photo);

                setting.Photo = FileManager.Upload(Photo);
            }
            if (ModelState.IsValid)
            {
                db.Entry(setting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setting);
        }

        // GET: Manage/Settings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: Manage/Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Setting setting = db.Settings.Find(id);
            db.Settings.Remove(setting);
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
