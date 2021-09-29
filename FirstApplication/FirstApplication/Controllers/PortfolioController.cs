using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApplication.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Bio()
        {
            return View();
        }

        public ActionResult Education()
        {
            return View();
        }

        public ActionResult PersonalInfo()
        {
            return View();
        }

        public ActionResult TechnicalSkills()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Reference()
        {
            return View();
        }
    }
}