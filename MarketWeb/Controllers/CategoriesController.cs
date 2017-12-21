using MarketWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MarketWeb.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            using (Service1Client srvc = new Service1Client())
            {

                return View(srvc.GetCategories());
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] ServiceReference1.TB_CategorySurrogate category)
        {
            if (ModelState.IsValid)
            {
                using (Service1Client srvc = new Service1Client())
                {
                    srvc.AddCategory(category);
                    return RedirectToAction("Index");
                }
            }
            return View(category);
        }


        public ActionResult Delete(int id)
        {
            using (Service1Client srvc = new Service1Client())
            {
                srvc.DeleteCategory(id);
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(ServiceReference1.TB_CategorySurrogate category,int categoryID)
        {
            if (category == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName")] ServiceReference1.TB_CategorySurrogate category)
        {
            if (ModelState.IsValid)
            {
                using (Service1Client srvc = new Service1Client())
                {
                    srvc.UpdateCategory(category);
                    return RedirectToAction("Index");
                }
            }
            return View(category);
        }
    }
}