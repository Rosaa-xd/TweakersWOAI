using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tweakers.Controllers
{
    public class UserListController : Controller
    {
        // GET: UserList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WishList(int id)
        {
            return View();
        }

        public ActionResult Inventory(int id)
        {
            return View();
        }
    }
}