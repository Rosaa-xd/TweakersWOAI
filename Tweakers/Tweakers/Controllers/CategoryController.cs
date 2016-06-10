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
        /// RedirectToAction("ProductCat" + id, "Product")
        /// </returns>
        private ActionResult SubCategory(int id)
        {
            if (Category.ReturnAllSubCategories(id).Count != 0)
            {
                return View(Category.ReturnAllSubCategories(id));
            }
            return RedirectToAction("ProductCat" + id, "Product");
        }

        #region Categories
        public ActionResult Cat1()
        {
            return SubCategory(1);
        }

        public ActionResult Cat2()
        {
            return SubCategory(2);
        }

        public ActionResult Cat3()
        {
            return SubCategory(3);
        }

        public ActionResult Cat4()
        {
            return SubCategory(4);
        }

        public ActionResult Cat5()
        {
            return SubCategory(5);
        }

        public ActionResult Cat6()
        {
            return SubCategory(6);
        }

        public ActionResult Cat7()
        {
            return SubCategory(7);
        }

        public ActionResult Cat8()
        {
            return SubCategory(8);
        }

        public ActionResult Cat9()
        {
            return SubCategory(9);
        }

        public ActionResult Cat10()
        { 
            return SubCategory(10);
        }

        public ActionResult Cat11()
        {
            return SubCategory(11);
        }

        public ActionResult Cat12()
        {
            return SubCategory(12);
        }

        public ActionResult Cat13()
        {
            return SubCategory(13);
        }

        public ActionResult Cat14()
        {
            return SubCategory(14);
        }

        public ActionResult Cat15()
        {
            return SubCategory(15);
        }

        public ActionResult Cat16()
        {
            return SubCategory(16);
        }

        public ActionResult Cat17()
        {
            return SubCategory(17);
        }

        public ActionResult Cat18()
        {
            return SubCategory(18);
        }

        public ActionResult Cat19()
        {
            return SubCategory(19);
        }
        #endregion
    }
}