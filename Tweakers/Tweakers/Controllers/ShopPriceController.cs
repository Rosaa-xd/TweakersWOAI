using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweakers.Models;

namespace Tweakers.Controllers
{
    public class ShopPriceController : Controller
    {
        public ActionResult ShopPricesProduct(int id)
        {
            return View(Dictionaries.Products[id]);
        }
    }
}