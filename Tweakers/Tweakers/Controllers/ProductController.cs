using System.Web.Mvc;
using Tweakers.Models;

namespace Tweakers.Controllers
{
    /// <summary>
    /// Controller class for Product
    /// </summary>
    public class ProductController : Controller
    {
        /// <summary>
        /// This is the ActionResult of the ProductCat View.
        /// It automatically generates all the products within a category
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View(Models.Product.FindAllProductsInCategory(id))</returns>
        public ActionResult ProductCat(int id)
        {
            return View(Models.Product.FindAllProductsInCategory(id));
        }

        /// <summary>
        /// This is the ActionResult of the Product View.
        /// It only contain a return View statement which redirects to the ShopPricesProduct
        /// and pass along the right product from the Dictionary..
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View("ShopPricesProduct", Dictionaries.Products[id])</returns>
        public ActionResult Product(int id)
        {
            return View("ShopPricesProduct", Dictionaries.Products[id]);
        }
        
        /// <summary>
        /// This ActionResult returns the ShopPricesProduct View.
        /// There all the shop prices of a product will be generated and shown.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View(Dictionaries.Products[id])</returns>
        public ActionResult ShopPricesProduct(int id)
        {
            return View(Dictionaries.Products[id]);
        }

        /// <summary>
        /// This ActionResult returns the SpecsProduct View.
        /// There all the specifications of a product will be generated and shown.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View(Dictionaries.Products[id])</returns>
        public ActionResult SpecsProduct(int id)
        {
            return View(Dictionaries.Products[id]);
        }

        /// <summary>
        /// This ActionResult returns the ReviewsProduct View.
        /// There all the reviews of a product will be generated and shown.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View(Dictionaries.Products[id])</returns>
        public ActionResult ReviewsProduct(int id)
        {
            return View(Dictionaries.Products[id]);
        }
    }
}