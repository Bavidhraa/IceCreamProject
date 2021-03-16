using IceCreamProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IceCreamProject.Controllers
{
    public class AdminController : Controller
    {
        icecreamprojectEntities9 db = new icecreamprojectEntities9();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Feedback()
        {
            return View(db.tbl_feedback.ToList().OrderByDescending(x => x.f_id));
        }

        [HttpGet]
        public ActionResult AddFlavour()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFlavour(tbl_flavour fl)
        {

            string fileName = Path.GetFileNameWithoutExtension(fl.ImageFile.FileName);
            string extension = Path.GetExtension(fl.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            fl.fl_image = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            fl.ImageFile.SaveAs(fileName);
            using (icecreamprojectEntities9 db = new icecreamprojectEntities9())
            {
                db.tbl_flavour.Add(fl);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View();

        }
        [HttpGet]
        public ActionResult Addbook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addbook(tbl_book b)
        {
            return View();
        }

    }
}