using System.Web.Mvc;

namespace Tweakers.Controllers
{
    /// <summary>
    /// Controller class for ProductType
    /// </summary>
    public class ProductTypeController : Controller
    {
        /// <summary>
        /// This is the ActionResult of the ProductType View
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductType()
        {
            return View();
        }
    }
}