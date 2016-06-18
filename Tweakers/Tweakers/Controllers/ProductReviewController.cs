using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweakers.Models;

namespace Tweakers.Controllers
{
    public class ProductReviewController : Controller
    {
        private List<ProductReview> prs = new List<ProductReview>();
        private User user = Models.User.FindByName(System.Web.HttpContext.Current.User.Identity.Name);

        [Authorize]
        public ActionResult WriteReview(int id)
        {
            ProductReview pr = new ProductReview(user, Dictionaries.Products[id], DateTime.MinValue, 0, null);
            prs.Add(pr);
            return View();
        }

        [HttpPost]
        public ActionResult WriteReview(int score, string explanation)
        {
            ProductReview pr = prs.Find(review => review.User.ID.Equals(user.ID));
            pr.Score = score;
            pr.Explanation = explanation;
            ProductReview.SaveProductReview(pr);
            return RedirectToAction("Product", "Product", pr.Product.ID);
        }
    }
}