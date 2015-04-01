using Auravana.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auravana.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonRepository _repos;

        public HomeController(IPersonRepository repos)
        {
            if (repos == null)
                throw new ArgumentNullException("repos");

            _repos = repos;
        }
                
        public ActionResult Index(string username)
        {
            var person = _repos.People.SingleOrDefault(p => p.Username.ToUpperInvariant() == username.ToUpperInvariant());
            return View(person);
        }
    }
}