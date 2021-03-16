using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IceCreamProject.Models;

namespace IceCreamProject.Controllers
{
    public class FeedBackController : Controller
    {
        private icecreamprojectEntities9 db = new icecreamprojectEntities9();

        // GET: FeedBack
        public ActionResult Index()
        {

         var tbl_feedback = db.tbl_feedback.Include(t => t.TBL_USER);
          return View(tbl_feedback.ToList());
        }
        [HttpPost]
       

        // GET: FeedBack/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_feedback tbl_feedback = db.tbl_feedback.Find(id);
            if (tbl_feedback == null)
            {
                return HttpNotFound();
            }
            return View(tbl_feedback);
        }

        // GET: FeedBack/Create
        public ActionResult Create()
        {
            ViewBag.UserFeed_id = new SelectList(db.TBL_USER, "u_id", "u_name");
            return View();
        }

        // POST: FeedBack/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "f_id,f_text,f_email,f_name,f_contact,UserFeed_id,Admin_Reply")] tbl_feedback tbl_feedback)
        {
            if (ModelState.IsValid)
            {
                db.tbl_feedback.Add(tbl_feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserFeed_id = new SelectList(db.TBL_USER, "u_id", "u_name", tbl_feedback.UserFeed_id);
            return View(tbl_feedback);
        }

        // GET: FeedBack/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_feedback tbl_feedback = db.tbl_feedback.Find(id);
            if (tbl_feedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserFeed_id = new SelectList(db.TBL_USER, "u_id", "u_name", tbl_feedback.UserFeed_id);
            return View(tbl_feedback);
        }

        // POST: FeedBack/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "f_id,f_text,f_email,f_name,f_contact,UserFeed_id,Admin_Reply")] tbl_feedback tbl_feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserFeed_id = new SelectList(db.TBL_USER, "u_id", "u_name", tbl_feedback.UserFeed_id);
            return View(tbl_feedback);
        }
        
        // GET: FeedBack/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_feedback tbl_feedback = db.tbl_feedback.Find(id);
            if (tbl_feedback == null)
            {
                return HttpNotFound();
            }
            return View(tbl_feedback);
        }

        // POST: FeedBack/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_feedback tbl_feedback = db.tbl_feedback.Find(id);
            db.tbl_feedback.Remove(tbl_feedback);
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
