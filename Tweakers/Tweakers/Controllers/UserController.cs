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
        /// <summary>
        /// This is the ActionResult of the Login View.
        /// It loads the View for the user.
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// This is the ActionResult of the Login View.
        /// It will log someone in with the right credentials.
        /// It will notify the user if the credentials are not correct.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns>
        /// return RedirectToAction("Index", "Home")
        /// return View()</returns>
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
        
        /// <summary>
        /// This method will check with the User model if the given username and password combination is correct
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns>bool</returns>
        public bool ValidLogin(string name, string password)
        {
            User user = Models.User.FindByLogin(name, password);

            if (user != null)
            {
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// This is the ActionResult of Logout
        /// It logs a logged in user out.
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}