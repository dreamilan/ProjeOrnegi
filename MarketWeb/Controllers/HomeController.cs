
using MarketWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MarketWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var q = Session["UserId"];
            if (Session["UserId"] != null)
                return RedirectToAction("Index", "Products");
            else
            return View();
        }
        
        [HttpPost]
        public ActionResult LoginUser(string username,string password)
        {
            
            using (Service1Client srvc = new Service1Client())
            {
                TB_UserSurrogate sonuc = srvc.UserLogin(username, password);
                if (sonuc != null)
                {
                    Session["UserId"] = sonuc.UserID;
                    Session["Username"] = sonuc.Username;
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult RegisterUser(TB_UserSurrogate kayit)
        {
           
            using (Service1Client srvc = new Service1Client())
            {
                if (srvc.UserRegister(kayit))
                {
                    LoginUser(kayit.Username, kayit.Password);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}