using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweakers.Models;

namespace Tweakers.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult PriceWatch()
        {
            return View(Category.ReturnAllParentCategories());
        }

        /// <summary>
        /// Method to automatically generate the right view for the corresponding category.
        /// If the category doens't have any subcategories, the method will redirect it to the corresponding ProductCategory
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