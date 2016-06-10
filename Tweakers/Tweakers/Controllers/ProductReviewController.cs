using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tweakers.Controllers
{
    public class ProductReviewController : Controller
    {
        // GET: ProductReview
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult WriteReview()
        {
            return View();
        }
    }
}