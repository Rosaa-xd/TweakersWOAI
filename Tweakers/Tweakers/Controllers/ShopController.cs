using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tweakers.Controllers
{
    /// <summary>
    /// Controller class for Shop
    /// </summary>
    public class ShopController : Controller
    {
        /// <summary>
        /// This is the ActionResult for the Shop View
        /// </summary>
        /// <returns></returns>
        public ActionResult Shop()
        {
            return View();
        }
    }
}