using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADODisconnectedExample.Controllers
{
    public class CategoryController : Controller
    {
        //
        CategoryHelper ch = new CategoryHelper();

        public ActionResult Index()
        {
            IEnumerable<Category> category = ch.GetCategories();
            return View(category);
        }
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post(string option, string search)
        {
            IEnumerable<Category> category = null;
            if (option == "Divison")
            {

                category = ch.GetCategories().Where(x => x.Division == search || search == null).ToList();
                return View(category);
            }
            else if (option == "Region")
            {
                category = ch.GetCategories().Where(x => x.Region == search || search == null).ToList();
                return View(category);
            }
            else if (option == "Supplier Id")
            {
                category = ch.GetCategories().Where(x => x.SupplierId == search || search == null).ToList();
                return View(category);
            }
            else if (option == "Supplier Name")
            {
                category = ch.GetCategories().Where(x => x.SupplierName == search || search == null).ToList();
                return View(category);
            }
            else
            {
                category = ch.GetCategories().Where(x => x.CategoryCode == search || search == null).ToList();
                return View(category);
            }

        }
        public ActionResult CategoryCodeEditor(string Id)
        {
            IEnumerable<Category> category = ch.GetCategories();

            Category selectedData = category.Where(x => x.CategoryCode == Id).ToList().FirstOrDefault();
            return View(selectedData);
        }
        [HttpPost]
        [ActionName("CategoryCodeEditor")]
        public ActionResult CategoryCodeEditor_Post(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                Category c = new Category();
                c.CategoryCode = form["CategoryCode"];
                c.CategoryName = form["CategoryName"];
                c.Division = form["Division"];
                c.Region = form["Region"];
                c.SupplierId = form["SupplierId"];
                c.SupplierName = form["SupplierName"];
                
                ch.UpdateCategory(c);
            }
            return RedirectToAction("Index");
        }
        public ActionResult DetailsCategory(string Id)
        {
            IEnumerable<Category> category = ch.GetCategories();

            Category selectedData = category.Where(x => x.CategoryCode == Id).ToList().FirstOrDefault();
            return View(selectedData);
        }
    }
}