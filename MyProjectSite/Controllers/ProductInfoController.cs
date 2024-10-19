using MyProjectSite.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectSite.Controllers
{
    public class ProductInfoController : Controller
    {
        MyAppDBContext db = new MyAppDBContext();

        //ADD TO CART

        public ActionResult AddToCart(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            OrderDetail OD = new OrderDetail
            {
                ProductID = id,
                Quantity = 1,
                UnitPrice = product.UnitPrice,
                TotalAmount = product.UnitPrice,
                Product = product
            };

            if (TempShopData.items == null)
            {
                TempShopData.items = new List<OrderDetail>();
            }
            TempShopData.items.Add(OD);

            string returnUrl = TempData["returnURL"] as string;
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }




        public ActionResult ViewDetails(int id, int? targetProductId = null)
        {
           
            var prod = db.Products.FirstOrDefault(p => p.ProductID == id);
            if (prod == null)
            { 
                return HttpNotFound();
            }

            ViewBag.RelatedProducts = db.Products.Where(y => y.CategoryID == prod.CategoryID && y.ProductID != id).ToList();
            ViewBag.ProductID = id;
           
            if (targetProductId.HasValue)
            {
                var targetProd = db.Products.FirstOrDefault(p => p.ProductID == targetProductId.Value);
                if (targetProd != null)
                {
                    ViewBag.TargetProduct = targetProd;
                }
            }

            this.GetDefaultData();

           
            return View(prod);
        }



        public ActionResult WishList(int id)
        {

            if (TempShopData.UserID == null)
            {
                return RedirectToAction("Login", "Account");
            }

            Wishlist wl = new Wishlist();
            wl.ProductID = id;
            wl.CustomerID = TempShopData.UserID;


            db.Wishlists.Add(wl);
            db.SaveChanges();


            ViewBag.WlItemsNo = db.Wishlists.Count(x => x.CustomerID == TempShopData.UserID);


            if (TempData["returnURL"] == null || string.IsNullOrEmpty(TempData["returnURL"].ToString()))
            {
                return RedirectToAction("Index", "Home");
            }

            string returnUrl = TempData["returnURL"].ToString();
            if (returnUrl == "/")
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(returnUrl);
        }



        public ActionResult GetProducts(int? subCatID)
        {
            var categories = db.Categories.Select(x => x.Name).ToList();
            var prods = subCatID.HasValue
                        ? db.Products.Where(y => y.SubCategoryID == subCatID).ToList()
                        : new List<Product>();

            var viewModel = new ProductViewModel
            {
                Categories = categories,
                Products = prods
            };

            return View(viewModel);
        }

        public ActionResult GetProductsByCategory(string categoryName, int? page, string sortOrder, decimal? minPrice, decimal? maxPrice)
        {
          
            ViewBag.Categories = db.Categories.Select(x => x.Name).ToList();
            ViewBag.SubCategories = db.SubCategories.Select(x => x.Name).ToList();

            var products = db.Products.Where(x => x.SubCategory.Name == categoryName);

           
            if (minPrice.HasValue)
            {
                products = products.Where(x => x.UnitPrice >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                products = products.Where(x => x.UnitPrice <= maxPrice.Value);
            }

           
            switch (sortOrder)
            {
                case "price_asc":
                    products = products.OrderBy(x => x.UnitPrice);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(x => x.UnitPrice);
                    break;
                default:
                    products = products.OrderBy(x => x.Name);
                    break;
            }

           
            var pagedProducts = products.ToList().ToPagedList(page ?? 1, 9);

            return View("Products", pagedProducts);
        }

        public ActionResult Search(string product, int? page)
        {
            ViewBag.SubCategories = db.SubCategories.Select(x => x.Name).ToList();
            ViewBag.CurrentFilter = product;

            List<Product> products;
            if (!string.IsNullOrEmpty(product))
            {
                products = db.Products.Where(x => x.Name.StartsWith(product)).ToList();
            }
            else
            {
                products = db.Products.ToList();
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View("Products", products.ToPagedList(pageNumber, pageSize));
        }




        public JsonResult GetProducts(string term)
        {
            List<string> prodNames = db.Products.Where(x => x.Name.StartsWith(term)).Select(y => y.Name).ToList();
            return Json(prodNames, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterByPrice(int minPrice, int maxPrice, int? page)
        {
            ViewBag.SubCategories = db.SubCategories.Select(x => x.Name).ToList();
            ViewBag.filterByPrice = true;
            var filterProducts = db.Products.Where(x => x.UnitPrice >= minPrice && x.UnitPrice <= maxPrice).ToList();
            return View("Products", filterProducts.ToPagedList(page ?? 1, 9));
        }
    }
}