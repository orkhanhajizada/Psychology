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
    public class PhrasesController : Controller
    {
        private PsychologyContext db = new PsychologyContext();

        // GET: Manage/Phrases
        public ActionResult Index()
        {
            return View(db.Phrases.ToList());
        }

        

        // GET: Manage/Phrases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Phrases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Text,Photo,OrderBy")] Phrase phrase, HttpPostedFileBase Photo)
        {
            if(Photo == null)
            {
                ModelState.AddModelError("Photo", "Please Select file");
            }
            else
            {
                phrase.Photo = FileManager.Upload(Photo);;
            }
            if (ModelState.IsValid)
            {
                db.Phrases.Add(phrase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phrase);
        }

        // GET: Manage/Phrases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phrase phrase = db.Phrases.Find(id);
            if (phrase == null)
            {
                return HttpNotFound();
            }
            return View(phrase);
        }

        // POST: Manage/Phrases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Text,Photo,OrderBy")] Phrase phrase, HttpPostedFileBase Photo)
        {
            db.Entry(phrase).State = EntityState.Modified;

            if (Photo == null)
            {
                db.Entry(phrase).Property(a => a.Photo).IsModified = false;
            }
            else
            {
                FileManager.Delete(phrase.Photo);

                phrase.Photo = FileManager.Upload(Photo);
            }
            if (ModelState.IsValid)
            {
                db.Entry(phrase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phrase);
        }

        // GET: Manage/Phrases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phrase phrase = db.Phrases.Find(id);
            if (phrase == null)
            {
                return HttpNotFound();
            }
            return View(phrase);
        }

        // POST: Manage/Phrases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phrase phrase = db.Phrases.Find(id);
            db.Phrases.Remove(phrase);
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
