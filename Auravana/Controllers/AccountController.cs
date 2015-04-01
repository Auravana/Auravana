using Auravana.Infrastructure.Abstract;
using Auravana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auravana.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthProvider _authProvider;

        public AccountController(IAuthProvider authProvider)
        {
            if (authProvider == null)
                throw new ArgumentNullException("authProvider");

            _authProvider = authProvider;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Home", new { Username = model.UserName }));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}