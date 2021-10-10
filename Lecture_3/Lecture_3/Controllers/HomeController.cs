using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lecture_3.Models;
using System.Web.Security;
using Lecture_3.Models.Entity;

namespace Lecture_3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username,string Password)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                var user = db.Users.Authenticate(Username, Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username,false);
                    //to signout
                    //FormsAuthentication.SignOut();
                    return RedirectToAction("Index", "Student");
                }
                ViewBag.Messege = "Invalid Username and Password";
                /*Session.Remove("logged");
                Session.Abandon();
                Session.RemoveAll();*/
                return View();

            }
          
            
            return View();
        }
    }
}