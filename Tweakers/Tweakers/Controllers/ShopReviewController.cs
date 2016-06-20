using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tweakers.Controllers
{
    /// <summary>
    /// Controller class for ShopReview
    /// </summary>
    public class ShopReviewController : Controller
    {
        /// <summary>
        /// This is the ActionResult of the ShopReview View
        /// </summary>
        /// <returns></returns>
        public ActionResult ShopReview()
        {
            return View();
        }
    }
}