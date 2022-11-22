using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modül_15.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Controller yapımız tanımlandı
        //Şindi uygulama üzerinde Home/CustomHttp pathname ile erişebiliriz
        public ActionResult CustomHttp()
        {
            return View();
        }
    }
}