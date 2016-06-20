using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tweakers.Controllers
{
    /// <summary>
    /// Controller class for UserList
    /// </summary>
    public class UserListController : Controller
    {
        /// <summary>
        /// This is the ActionResult that loads the WishList View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult WishList(int id)
        {
            return View();
        }

        /// <summary>
        /// Thisis the ActionResult that loads the Inventory View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Inventory(int id)
        {
            return View();
        }
    }
}