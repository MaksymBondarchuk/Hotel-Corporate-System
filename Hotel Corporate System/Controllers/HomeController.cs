using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Corporate_System.Controllers
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
            ViewBag.Message = "Login to the system";

            return View();
        }

		public ActionResult Porter()
        {
            return View();
        }

		public ActionResult FrontOffice()
        {
            return View();
        }

		public ActionResult BackOffice()
        {
            return View();
        }

		public ActionResult Director()
        {
            return View();
        }

		public ActionResult Accountant()
        {
            return View();
        }
    }
}