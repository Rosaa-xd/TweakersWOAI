using System.Web.Mvc;

namespace Tweakers.Controllers
{
    /// <summary>
    /// Controller class for Asset
    /// </summary>
    public class AssetController : Controller
    {
        /// <summary>
        /// This is the ActionResult for the Asset View
        /// </summary>
        /// <returns></returns>
        public ActionResult Asset()
        {
            return View();
        }
    }
}