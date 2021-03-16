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
    public class RecipeController : Controller
    {
        private icecreamprojectEntities9 db = new icecreamprojectEntities9();

        // GET: Recipe
        public ActionResult Index()
        {
            var tbl_recipe = db.tbl_recipe.Include(t => t.tbl_flavour).Include(t => t.TBL_USER);
            return View(tbl_recipe.ToList());
        }

        // GET: Recipe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_recipe tbl_recipe = db.tbl_recipe.Find(id);
            if (tbl_recipe == null)
            {
                return HttpNotFound();
            }
            return View(tbl_recipe);
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            ViewBag.fl_ref = new SelectList(db.tbl_flavour, "fl_id", "fl_name");
            ViewBag.userid = new SelectList(db.TBL_USER, "u_id", "u_name");
            return View();
        }

        // POST: Recipe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "r_id,r_name,r_desc,userid,Admin_Reply,fl_ref")] tbl_recipe tbl_recipe)
        {
            if (ModelState.IsValid)
            {
                db.tbl_recipe.Add(tbl_recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fl_ref = new SelectList(db.tbl_flavour, "fl_id", "fl_name", tbl_recipe.fl_ref);
            ViewBag.userid = new SelectList(db.TBL_USER, "u_id", "u_name", tbl_recipe.userid);
            return View(tbl_recipe);
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_recipe tbl_recipe = db.tbl_recipe.Find(id);
            if (tbl_recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.fl_ref = new SelectList(db.tbl_flavour, "fl_id", "fl_name", tbl_recipe.fl_ref);
            ViewBag.userid = new SelectList(db.TBL_USER, "u_id", "u_name", tbl_recipe.userid);
            return View(tbl_recipe);
        }

        // POST: Recipe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "r_id,r_name,r_desc,userid,Admin_Reply,fl_ref")] tbl_recipe tbl_recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fl_ref = new SelectList(db.tbl_flavour, "fl_id", "fl_name", tbl_recipe.fl_ref);
            ViewBag.userid = new SelectList(db.TBL_USER, "u_id", "u_name", tbl_recipe.userid);
            return View(tbl_recipe);
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_recipe tbl_recipe = db.tbl_recipe.Find(id);
            if (tbl_recipe == null)
            {
                return HttpNotFound();
            }
            return View(tbl_recipe);
        }

        // POST: Recipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_recipe tbl_recipe = db.tbl_recipe.Find(id);
            db.tbl_recipe.Remove(tbl_recipe);
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
