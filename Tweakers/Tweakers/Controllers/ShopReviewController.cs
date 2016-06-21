using System.Web.Mvc;

namespace Tweakers.Controllers
{
    /// <summary>
    /// Controller class for ShopReview
    /// </summary>
    public class ShopReviewController : Controller
    {
        /// <summary>
        /// This is the ActionResult for the ShopReview View
        /// </summary>
        /// <returns></returns>
        public ActionResult ShopReview()
        {
            return View();
        }
    }
}