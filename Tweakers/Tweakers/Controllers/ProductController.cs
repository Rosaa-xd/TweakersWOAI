using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweakers.Models;

namespace Tweakers.Controllers
{
    public class ProductController : Controller
    {
        /// <summary>
        /// Method to automatically generate all the products within a category
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View(Models.Product.FindAllProductsInCategory(id)</returns>
        public ActionResult ProductCat(int id)
        {
            return View(Models.Product.FindAllProductsInCategory(id));
        }

        /// <summary>
        /// These are the ActionResults of the Product View.
        /// They only contain a return View statement which redirects to the ShopPricesProduct
        /// and pass along the right product from the Dictionary..
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View("ShopPricesProduct", Dictionaries.Products[id]</returns>
        public ActionResult Product(int id)
        {
            return View("ShopPricesProduct", Dictionaries.Products[id]);
        }
        
        public ActionResult ShopPricesProduct(int id)
        {
            return View(Dictionaries.Products[id]);
        }

        public ActionResult SpecsProduct(int id)
        {
            return View(Dictionaries.Products[id]);
        }

        public ActionResult ReviewsProduct(int id)
        {
            return View(Dictionaries.Products[id]);
        }
    }
}