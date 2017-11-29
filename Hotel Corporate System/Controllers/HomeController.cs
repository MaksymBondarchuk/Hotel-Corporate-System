using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Corporate_System.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		[Authorize]
		public ActionResult Index()
		{
			return View();
		}

		[Authorize(Roles = "Porter,Director")]
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		[Authorize(Roles = "Porter")]
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		[Authorize]
		public ActionResult Login()
		{
			ViewBag.Message = "Login to the system";

			return View();
		}

		[Authorize]
		public ActionResult Porter()
		{
			return View();
		}

		[Authorize]
		public ActionResult FrontOffice()
		{
			return View();
		}

		[Authorize]
		public ActionResult BackOffice()
		{
			return View();
		}

		[Authorize]
		public ActionResult Director()
		{
			return View();
		}

		[Authorize]
		public ActionResult Accountant()
		{
			return View();
		}
	}
}