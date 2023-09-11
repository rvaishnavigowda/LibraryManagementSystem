using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user)
        {
            if (user == "Librarian")
                return RedirectToAction("LibrarianLogin", "Librarian");
            else
                return RedirectToAction("StudentLogin", "Student");
        }
    }
}
