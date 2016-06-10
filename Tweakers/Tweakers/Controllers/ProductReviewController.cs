using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweakers.Models;
using Microsoft.AspNet.Identity;

namespace Tweakers.Controllers
{
    public class ProductReviewController : Controller
    {
        [Authorize]
        public ActionResult WriteReview(int id)
        {
            ProductReview pr = new ProductReview(Models.User.FindByName(User.Identity.GetUserName()),
                Dictionaries.Products[id], DateTime.Now, 0, null);
            return View(pr);
        }

        [HttpPost]
        [Authorize]
        public ActionResult WriteReview(User u, Product p, int score,
            string explanation)
        {
            return View();
        }
    }
}