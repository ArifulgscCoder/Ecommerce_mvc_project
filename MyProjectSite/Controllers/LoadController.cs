using MyProjectSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectSite.Controllers
{
    public static class LoadController
    {
        static MyAppDBContext db = new MyAppDBContext();
        public static List<OrderDetail> GetDefaultData(this ControllerBase controller)
        {
            if (TempShopData.items == null)
            {
                TempShopData.items = new List<OrderDetail>();
            }
            var data = TempShopData.items.ToList();

            controller.ViewBag.cartBox = data.Count == 0 ? null : data;
            controller.ViewBag.NoOfItem = data.Count();
            int? SubTotal = Convert.ToInt32(data.Sum(x => x.TotalAmount));
            controller.ViewBag.Total = SubTotal;

            int Discount = 0;
            controller.ViewBag.SubTotal = SubTotal;
            controller.ViewBag.Discount = Discount;
            controller.ViewBag.TotalAmount = SubTotal - Discount;

            controller.ViewBag.WishlistItemNo = db.Wishlists.Where(x => x.CustomerID == TempShopData.UserID).ToList().Count();
            return data;
        }
    }
}