using MyProjectSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectSite.Controllers
{
    public class WishlistController : Controller
    {
        MyAppDBContext db = new MyAppDBContext();

        // GET: WishList
        public ActionResult Index()
        {
            this.GetDefaultData();

            var wishlistProducts = db.Wishlists.Where(x => x.CustomerID == TempShopData.UserID).ToList();
            return View(wishlistProducts);
        }

        //REMOVE ITEM FROM WISHLIST
        public ActionResult Remove(int id)
        {
            db.Wishlists.Remove(db.Wishlists.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        //ADD TO CART WISHLIST
        public ActionResult AddToCart(int id)
        {
         
            var wishlistItem = db.Wishlists.Find(id);
            if (wishlistItem == null)
            {
                return RedirectToAction("Index", "Home"); 
            }

            int pid = wishlistItem.ProductID;

            OrderDetail OD = new OrderDetail();
            OD.ProductID = pid;

          
            var product = db.Products.Find(pid);
            if (product == null)
            {
                return RedirectToAction("Index", "Home"); 
            }

            int Qty = 1;
            decimal price = product.UnitPrice;
            OD.Quantity = Qty;
            OD.UnitPrice = price;
            OD.TotalAmount = Qty * price;
            OD.Product = product;

        
            if (TempShopData.items == null)
            {
                TempShopData.items = new List<OrderDetail>();
            }
            TempShopData.items.Add(OD);

            db.Wishlists.Remove(wishlistItem);
            db.SaveChanges();

        
            if (TempData["returnURL"] == null || string.IsNullOrEmpty(TempData["returnURL"].ToString()))
            {
                return RedirectToAction("Index", "Home"); 
            }

            string returnUrl = TempData["returnURL"].ToString();
            return Redirect(returnUrl);
        }

    }
}