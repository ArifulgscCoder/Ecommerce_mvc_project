using MyProjectSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectSite.Controllers
{
    public class DashBoardController : Controller
    {
        MyAppDBContext db = new MyAppDBContext();
        public ActionResult Index()
        {

            ViewBag.latestOrders = db.Orders.OrderByDescending(x => x.OrderID).Take(10).ToList();
          
            return View();
        }
    }
}