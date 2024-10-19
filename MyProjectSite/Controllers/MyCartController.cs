using MyProjectSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectSite.Controllers
{
    public class MyCartController : Controller
    {
        MyAppDBContext db = new MyAppDBContext();

        // GET: MyCart
        public ActionResult Index()
        {
            var data = this.GetDefaultData();

            return View(data);

        }

        public ActionResult Remove(int id)
        {
            TempShopData.items.RemoveAll(x => x.ProductID == id);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult ProcedToCheckout(FormCollection formcoll)
        {
            var a = TempShopData.items.ToList();
            for (int i = 0; i < formcoll.Count / 2; i++)
            {

                int pID = Convert.ToInt32(formcoll["shcartID-" + i + ""]);
                var ODetails = TempShopData.items.FirstOrDefault(x => x.ProductID == pID);


                int qty = Convert.ToInt32(formcoll["Qty-" + i + ""]);
                ODetails.Quantity = qty;
                ODetails.UnitPrice = ODetails.UnitPrice;
                ODetails.TotalAmount = qty * ODetails.UnitPrice;
                TempShopData.items.RemoveAll(x => x.ProductID == pID);

                if (TempShopData.items == null)
                {
                    TempShopData.items = new List<OrderDetail>();
                }
                TempShopData.items.Add(ODetails);

            }

            return RedirectToAction("Index", "CheckOut");
        }
    }
}