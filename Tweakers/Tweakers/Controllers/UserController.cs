using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tweakers.Models;

namespace Tweakers.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            if (ValidLogin(name, password))
            {
                FormsAuthentication.SetAuthCookie(name, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Uw gebruikersnaam of wachtwoord is onjuist");
            return View();
        }
        

        public bool ValidLogin(string name, string password)
        {
            User user = Models.User.FindByLogin(name, password);

            if (user != null)
            {
                return true;
            }
            return false;
        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}