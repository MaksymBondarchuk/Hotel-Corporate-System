﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Hotel_Corporate_System.Models;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Hotel_Corporate_System.Controllers
{
	public class LoginController : Controller
	{
		private SignInManager<IdentityUser, string> _signInManager;

		public SignInManager<IdentityUser, string> SignInManager
		{
			//get => _signInManager;// ?? HttpContext.GetOwinContext().Get<SignInManager<IdentityUser, string>>();
			//private set => _signInManager = value;
			get;
			set;
		}

		// GET: Login
		[AllowAnonymous]
		public ActionResult Index(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		// GET: Login/Login
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
			//HttpContext.GetOwinContext().Get<SignInManager<IdentityUser, string>>();

			//if (!ModelState.IsValid)
			//{
			//	return RedirectToAction("Porter", "Home");
			//}

			//// This doesn't count login failures towards account lockout
			//// To enable password failures to trigger account lockout, change to shouldLockout: true
			//var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
			//switch (result)
			//{
			//	case SignInStatus.Success:
			//		return RedirectToLocal(returnUrl);
			//	case SignInStatus.LockedOut:
			//	//return View("Lockout");
			//	case SignInStatus.RequiresVerification:
			//	//return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
			//	case SignInStatus.Failure:
			//	default:
			//		{
			//			ModelState.AddModelError("", "Invalid login attempt.");
			//			return View(model);
			//		}
			//}


			//if (!ModelState.IsValid)
			//{
			//	return View(model);
			//}

			//User user = new User() { Email = model.Email, Password = model.Password };

			//user = Repository.GetUserDetails(user);

			//if (user != null)
			//{
			//	FormsAuthentication.SetAuthCookie(model.Email, false);

			//	var authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Roles);
			//	string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
			//	var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
			//	HttpContext.Response.Cookies.Add(authCookie);
			//	return RedirectToAction("Index", "Home");
			//}

			ModelState.AddModelError("", "Invalid login attempt.");
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