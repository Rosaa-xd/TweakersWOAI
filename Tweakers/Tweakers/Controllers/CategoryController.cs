using System.Web.Mvc;
using Tweakers.Models;

namespace Tweakers.Controllers
{
    /// <summary>
    /// Controller class for Category
    /// </summary>
    public class CategoryController : Controller
    {
        /// <summary>
        /// This is the ActionResult of the PriceWatch View.
        /// It automatically generates all the parentcategories
        /// </summary>
        /// <returns>View(Category.ReturnAllParentCategories())</returns>
        public ActionResult PriceWatch()
        {
            return View(Category.ReturnAllParentCategories());
        }

        /// <summary>
        /// This is the ActionResult of the Cat View.
        /// It first checks if the category has any subcategories.
        /// If it has, then it will automatically generate all the subcategories.
        /// If not, it will redirect you to ProductCat
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// View(Category.ReturnAllSubCategories(id))
        /// RedirectToAction("ProductCat", "Product")
        /// </returns>
        public ActionResult Cat(int id)
        {
            if (Category.ReturnAllSubCategories(id).Count != 0)
            {
                return View(Category.ReturnAllSubCategories(id));
            }
            return RedirectToAction("ProductCat", "Product", new {id});
        }
    }
}