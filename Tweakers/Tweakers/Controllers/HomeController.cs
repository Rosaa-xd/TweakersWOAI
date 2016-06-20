using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tweakers.Controllers
{
    /// <summary>
    /// Controller class for Home
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// This is the ActionResult for the Index View 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}