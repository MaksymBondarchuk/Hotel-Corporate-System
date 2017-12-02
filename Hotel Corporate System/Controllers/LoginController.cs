using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Hotel_Corporate_System.Models;
using Hotel_Corporate_System.Models.Helpers;

namespace Hotel_Corporate_System.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var employee = LoginHelper.GetEmployee(model.Login, model.Password);

			if (employee != null)
			{
				FormsAuthentication.SetAuthCookie(model.Login, false);

				var authTicket = new FormsAuthenticationTicket(1, model.Login, DateTime.Now, DateTime.Now.AddMinutes(20), false, employee.Roles);
				string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
				var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
				HttpContext.Response.Cookies.Add(authCookie);
				return RedirectToAction("Index", "Home");
			}

			ModelState.AddModelError("", "Invalid login attempt");
			return View(model);
		}

		private ActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			return RedirectToAction("Index", "Home");
		}
	}
}