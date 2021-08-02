
using ShoppingCart_ASP.NET_MVC5.Dao;
using ShoppingCart_ASP.NET_MVC5.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShoppingCart_ASP.NET_MVC5.Controllers
{
    [SessionExpire]
    public class HomeController : Controller
    {

        public ActionResult Home()
        {
            List<CarModel> prolist = ProductDetails.Callme();
            ViewData["pl"] = prolist;
            ViewBag.a = 1;
            return View();
        }
    }
}