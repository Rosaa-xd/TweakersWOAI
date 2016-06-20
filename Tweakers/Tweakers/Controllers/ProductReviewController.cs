using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweakers.Models;

namespace Tweakers.Controllers
{
    /// <summary>
    /// Controller class for ProductReview
    /// </summary>
    public class ProductReviewController : Controller
    {
        private List<ProductReview> prs = new List<ProductReview>();
        private User user = Models.User.FindByName(System.Web.HttpContext.Current.User.Identity.Name);

        /// <summary>
        /// This is the ActionResult for the WriteReview View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult WriteReview(int id)
        {
            ProductReview pr = new ProductReview(user, Dictionaries.Products[id], DateTime.MinValue, 0, null);
            prs.Add(pr);
            return View();
        }

        /// <summary>
        /// This is the ActionResult of the WriteReview View which saves the created ProductReview
        /// </summary>
        /// <param name="score"></param>
        /// <param name="explanation"></param>
        /// <returns></returns>
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