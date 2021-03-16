using IceCreamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IceCreamProject.Controllers
{
    public class RegisterUserController : Controller
    {
        icecreamprojectEntities9 db = new icecreamprojectEntities9();

        public SelectList ViewBaglist { get; private set; }

        // GET: RegisterUser
        [HttpGet]
        public ActionResult Register()
        {
            List<TBL_MEMBERSHIP> li = db.TBL_MEMBERSHIP.ToList();
            ViewBag.list = new SelectList(li, "MEM_ID", "MEM_TYPE");
            return View();
        }
        [HttpPost]
       // [Route ("MyFirstPage")]
        public ActionResult Register(TBL_USER u)
        {
            try
            {
                TBL_USER ur = new TBL_USER();
                ur.u_id = u.u_id;
                ur.u_name = u.u_name;
                ur.u_email = u.u_email;
                ur.u_contact = u.u_contact;
                ur.u_password = u.u_password;
                ur.u_subs = u.u_subs;
                ur.u_cpassword = u.u_cpassword;
                ViewBag.userid = u.u_id;
                db.TBL_USER.Add(ur);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                // ViewBag.msg = e.Message;
                return RedirectToAction("ErrorPage");
            }

           
        }
        [HttpGet]
        public ActionResult Contact()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Contact(tbl_feedback feed)
        {
            
                try
                {  
                    
                    
                    db.tbl_feedback.Add(feed);
                    db.SaveChanges();
                    TempData["msg"] = "Your FeedBack is Submitted Successfully";
                    TempData.Keep();
                    return RedirectToAction("Contact");

                }
                catch (Exception)
                {
                    return RedirectToAction("ErrorPage");

                }
            
        }
        [HttpGet]
        public ActionResult ErrorPage()
        {
            return View();
        }

        public ActionResult AfterSignup()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBL_USER ui)

        {
            TBL_USER u = db.TBL_USER.Where(x => x.u_email == ui.u_email && x.u_password == ui.u_password).SingleOrDefault();

            if (u!=null)
            {
                TempData["purchase"] = ui.u_id;
                Session["uid"] = u.u_id;
                if (u.u_id == 13)
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Userpanel"); 
            } else
            {
                ViewBag.Message = "Invalid Password or Email Id";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login");
           
        }
        [HttpGet]
        public ActionResult Userpanel()
        {
            if(Session["uid"]==null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult ReplybyAdmin()
        {
            var joinresult = db.tbl_feedback.Join(db.TBL_USER,
    b => b.UserFeed_id,
    p => p.u_id,
    (b, p) => new { b.f_id, b.f_text, b.f_name, b.f_email, b.Admin_Reply });

            List<tbl_feedback> feedtable = new List<tbl_feedback>();

            //for(int i=0;i<result.Count();i++)
            foreach (var item in joinresult)
            {
                tbl_feedback tempbug = new tbl_feedback();
                tempbug.f_id = item.f_id;
                tempbug.f_name = item.f_name;
                tempbug.f_email = item.f_email;
                // tempbug.f_contact = item.f_contact;
                tempbug.f_text = item.f_text;
                tempbug.Admin_Reply = item.Admin_Reply;
                feedtable.Add(tempbug);


            }
            return View(feedtable);

        }
        public ActionResult ReplyforRecipe()
        {
            var joinresult = db.tbl_recipe.Join(db.TBL_USER,
       b => b.userid,
       p => p.u_id,
       (b, p) => new { b.r_id, b.r_desc, b.r_name, b.fl_ref });

            List<tbl_recipe> recipe = new List<tbl_recipe>();

            //for(int i=0;i<result.Count();i++)
            foreach (var item in joinresult)
            {
                tbl_recipe tempbug = new tbl_recipe();
                tempbug.r_id = item.r_id;
                tempbug.r_name = item.r_name;
                tempbug.r_desc = item.r_desc;
                // tempbug.f_contact = item.f_contact;
                //tempbug.f_text = item.f;
               // tempbug.Admin_Reply = item.Admin_Reply;
                recipe.Add(tempbug);


            }
            return View(recipe);

           
        }
        public ActionResult Order()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login");
                
            }
            return View();
        }
                public ActionResult About_Us()
        {
            return View();
        }
    }
}

