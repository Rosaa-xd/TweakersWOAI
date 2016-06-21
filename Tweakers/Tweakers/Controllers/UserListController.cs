using System.Web.Mvc;

namespace Tweakers.Controllers
{
    /// <summary>
    /// Controller class for UserList
    /// </summary>
    public class UserListController : Controller
    {
        /// <summary>
        /// This is the ActionResult for the WishList View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult WishList(int id)
        {
            return View();
        }

        /// <summary>
        /// This is the ActionResult for the Inventory View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Inventory(int id)
        {
            return View();
        }
    }
}