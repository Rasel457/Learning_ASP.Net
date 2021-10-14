using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Lecture_5.Models;

namespace Lecture_5.Controllers
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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string phone, string password)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                var customer = db.Customers.Authenticate(phone, password);
                if (customer != null)
                {
                    FormsAuthentication.SetAuthCookie(customer.Name, false);
                    Session["customerId"] = customer.Id;
                    //to signout
                    //FormsAuthentication.SignOut();
                    return RedirectToAction("List", "Product");
                }
                ViewBag.Messege = "Invalid Username and Password";
                return View();

            }
            return View();
        }
    }
}