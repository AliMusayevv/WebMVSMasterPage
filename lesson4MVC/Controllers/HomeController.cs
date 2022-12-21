using lesson4MVC.Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lesson4MVC.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db =new NorthwindEntities();
        public ActionResult Index()
        {
            var model=db.Orders.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult Yeni(string ad)
        {
            return View();
        }
    }
}