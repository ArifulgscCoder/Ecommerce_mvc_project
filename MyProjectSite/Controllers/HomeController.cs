using MyProjectSite.Models;
using MyProjectSite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

namespace MyProjectSite.Controllers
{
    public class HomeController : Controller
    {
        private MyAppDBContext db = new MyAppDBContext();

        public HomeController()
        {
            db=new MyAppDBContext();
        }

        // GET: Shopping
        public ActionResult Index()
        {
            var latestProducts = db.Products
                .OrderByDescending(p=>p.ProductID)
                .Take(8)
                .ToList();

            var categoryProduct=db.Products.GroupBy(P=>P.Category).Select(g=>g.FirstOrDefault()).ToList();

            var getAllProducts=db.Products.OrderBy(p=>p.ProductID).Take(20).ToList();

            var viewModel = new IndexProductsViewModel
            {
                LatestestProducts = latestProducts,
              CategoryProducts=  categoryProduct,
              GetAllProducts = getAllProducts
            };
            return View(viewModel);

        }

        public ActionResult ViewAllProducts(int page = 1, int pageSize = 20)
        {
            var totalProducts = db.Products.Count();
            var products = db.Products
                             .OrderBy(p => p.ProductID)
                             .Skip((page - 1) * pageSize)
                             .Take(6)
                             .ToList();

            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            var viewModel = new IndexProductsViewModel
            {
                GetAllProducts = products,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(viewModel);
        }


    }
}