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
    public class ChooseUsController : Controller
    {
        private PsychologyContext db = new PsychologyContext();

        // GET: Manage/ChooseUs
        public ActionResult Index()
        {
            return View(db.ChooseUs.ToList());
        }
        

        // GET: Manage/ChooseUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/ChooseUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,Text")] ChooseUs chooseUs)
        {
            if (ModelState.IsValid)
            {
                db.ChooseUs.Add(chooseUs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chooseUs);
        }

        // GET: Manage/ChooseUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChooseUs chooseUs = db.ChooseUs.Find(id);
            if (chooseUs == null)
            {
                return HttpNotFound();
            }
            return View(chooseUs);
        }

        // POST: Manage/ChooseUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Title,Text")] ChooseUs chooseUs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chooseUs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chooseUs);
        }

        // GET: Manage/ChooseUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChooseUs chooseUs = db.ChooseUs.Find(id);
            if (chooseUs == null)
            {
                return HttpNotFound();
            }
            return View(chooseUs);
        }

        // POST: Manage/ChooseUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChooseUs chooseUs = db.ChooseUs.Find(id);
            db.ChooseUs.Remove(chooseUs);
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
