using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IceCreamProject.Models;

namespace IceCreamProject.Controllers
{
    public class orderController : Controller
    {
        // GET: order
        icecreamprojectEntities9 db = new icecreamprojectEntities9();
        public ActionResult Index()
        {
            List<tbl_book> booklist = db.tbl_book.ToList();
            return View(booklist);
        }
        [HttpPost]
        public ActionResult Index(string option, string search)
        {

            //if a user choose the radio button option as Subject  
            if (option == "b_book")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(db.tbl_book.Where(x => x.b_name == search || search == null).ToList());
            }
            else if (option == "b_price")
            {
                return View(db.tbl_book.Where(x => x.b_price ==Convert.ToInt32( search) || search == null).ToList());
            }
            else
            {
                return View(db.tbl_book.Where(x => x.b_count== Convert.ToInt32(search) || search == null).ToList());
            }
        }

        // GET: order/Details/5
        public ActionResult purchase()
        {
            return View();
        }
        [HttpPost]
        public ActionResult purchase(int id,tbl_order order,tbl_book book)
        {
            var tb = db.tbl_book.Where(x => x.b_id == book.b_id).SingleOrDefault();

            return View();
        }

        // GET: order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
