using MarketWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketWeb.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(List<int> kategoriID, List<int> colorID, List<int> cityID, decimal? minPrice, decimal? maxPrice, DateTime? minTarih, DateTime? maxTarih)
        {
            var sonuc = new List<ServiceReference1.TB_ProductSurrogate>();
            using (Service1Client srvc = new Service1Client())
            {
                List<TB_CategorySurrogate> kategoriler = srvc.GetCategories();
                List<TB_CitySurrogate> sehirler = srvc.GetCities();
                List<TB_ColorSurrogate> renkler = srvc.GetColors();
                sonuc = srvc.GetProducts(kategoriID, colorID, cityID, minPrice, maxPrice, minTarih, maxTarih);
                ViewBag.Kategoriler = kategoriler;
                ViewBag.Sehirler = sehirler;
                ViewBag.Renkler = renkler;
                foreach (var item in sonuc)
                {
                    item.Category = kategoriler.FirstOrDefault(p => p.CategoryID == item.Category.CategoryID);
                    item.City = sehirler.FirstOrDefault(p => p.CityID == item.City.CityID);
                    item.Color = renkler.FirstOrDefault(p => p.ColoID == item.Color.ColoID);


                }
            }
            

            return View(sonuc);
        }

        public ActionResult Create()
        {
            using (Service1Client srvc = new Service1Client())
            {
                List<TB_CategorySurrogate> kategoriler = srvc.GetCategories();
                List<TB_CitySurrogate> sehirler = srvc.GetCities();
                List<TB_ColorSurrogate> renkler = srvc.GetColors();
                
                ViewBag.Kategoriler = kategoriler;
                ViewBag.Sehirler = sehirler;
                ViewBag.Renkler = renkler;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Title,Price,DateAdded")] ServiceReference1.TB_ProductSurrogate product,int ColorID,int CategoryID,int CityID)
        {
            if (ModelState.IsValid)
            {
                using (Service1Client srvc = new Service1Client())
                {
                    product.Color = new TB_ColorSurrogate { ColoID = ColorID };
                    product.City = new TB_CitySurrogate { CityID = CityID };
                    product.Category = new TB_CategorySurrogate { CategoryID = CategoryID };
                    srvc.AddProduct(product);
                    return RedirectToAction("Index");
                }
            }

            return View(product);
        }


        public ActionResult SignOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}