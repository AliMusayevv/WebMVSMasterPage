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
        public ActionResult Yeni(Order order)
        {
            if (order.OrderID==0) //demeli insert ucun
            {
                db.Orders.Add(order);
            }
            else
            {
                var updateData=db.Orders.Find(order.OrderID);
                if (updateData==null)
                {
                    return HttpNotFound();
                }
                updateData.ShipName=order.ShipName;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Update(int id)
        {
            //return View("Yeni");
            var model = db.Orders.Find(id);
            if (model==null)
            {
                return HttpNotFound();
            }
            return View("Yeni",model);
        }
    }
}