using MyProjectSite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectSite.Controllers
{
    public class ProductController : Controller
    {

        MyAppDBContext db = new MyAppDBContext();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());

        }


        // CREATE: Product

        public ActionResult Create()
        {
            
            ViewBag.categoryList = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.SubCategoryList = new SelectList(db.SubCategories, "SubCategoryID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel pvm)
        {

            if (ModelState.IsValid)
            {
                if (pvm.Picture != null)
                {
                    string filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(pvm.Picture.FileName));
                    pvm.Picture.SaveAs(Server.MapPath(filePath));

                    Product p = new Product
                    {
                        ProductID = pvm.ProductID,
                        Name = pvm.Name,
                      
                        CategoryID = pvm.CategoryID,
                        SubCategoryID = pvm.SubCategoryID,
                        UnitPrice = pvm.UnitPrice,
                        OldPrice = pvm.OldPrice,
                      
                        UnitInStock = pvm.UnitInStock,
                        
                        ShortDescription = pvm.ShortDescription,
                 
                        PicturePath = filePath
                    };
                    db.Products.Add(p);
                    db.SaveChanges();
                    return PartialView("_Success");
                }
            }
          
            return PartialView("_Error");
        }




        // EDIT: Product


        public ActionResult Edit(int id)
        {
            Product p = db.Products.Find(id);

            ProductViewModel pvm = new ProductViewModel
            {
                ProductID = p.ProductID,
                Name = p.Name,
               
                CategoryID = p.CategoryID,
                SubCategoryID = p.SubCategoryID,
                UnitPrice = p.UnitPrice,
                OldPrice = p.OldPrice,
               
                UnitInStock = p.UnitInStock,
                
                ShortDescription = p.ShortDescription,

                PicturePath = p.PicturePath

            };
         
            ViewBag.categoryList = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.SubCategoryList = new SelectList(db.SubCategories, "SubCategoryID", "Name");
            return View(pvm);
        }
        [HttpPost]

        public ActionResult Edit(ProductViewModel pvm)
        {

            if (ModelState.IsValid)
            {
                string filePath = pvm.PicturePath;
                if (pvm.Picture != null)
                {
                    filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(pvm.Picture.FileName));
                    pvm.Picture.SaveAs(Server.MapPath(filePath));

                    Product p = new Product
                    {
                        ProductID = pvm.ProductID,
                        Name = pvm.Name,
                       
                        CategoryID = pvm.CategoryID,
                        SubCategoryID = pvm.SubCategoryID,
                        UnitPrice = pvm.UnitPrice,
                        OldPrice = pvm.OldPrice,
                       
                        UnitInStock = pvm.UnitInStock,
                        
                        ShortDescription = pvm.ShortDescription,
                       
                        PicturePath = filePath
                    };
                    db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Product p = new Product
                    {
                        ProductID = pvm.ProductID,
                        Name = pvm.Name,
                      
                        CategoryID = pvm.CategoryID,
                        SubCategoryID = pvm.SubCategoryID,
                        UnitPrice = pvm.UnitPrice,
                        OldPrice = pvm.OldPrice,
                      
                        UnitInStock = pvm.UnitInStock,
                       
                        ShortDescription = pvm.ShortDescription,
                  
                        PicturePath = filePath
                    };
                    db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            
            ViewBag.categoryList = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.SubCategoryList = new SelectList(db.SubCategories, "SubCategoryID", "Name");
            return PartialView(pvm);
        }


        // DETAILS: Product
        public ActionResult Details(int id)
        {
            Product p = db.Products.Find(id);

            ProductViewModel pvm = new ProductViewModel
            {
                ProductID = p.ProductID,
                Name = p.Name,
              
                CategoryID = p.CategoryID,
                SubCategoryID = p.SubCategoryID,
                UnitPrice = p.UnitPrice,
                OldPrice = p.OldPrice,
              
                UnitInStock = p.UnitInStock,
              
                ShortDescription = p.ShortDescription,
      
                PicturePath = p.PicturePath

            };
          
            ViewBag.categoryList = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.SubCategoryList = new SelectList(db.SubCategories, "SubCategoryID", "Name");
            return View(pvm);
        }
        [HttpPost]

        public ActionResult Details(ProductViewModel pvm)
        {

            if (ModelState.IsValid)
            {
                string filePath = pvm.PicturePath;
                if (pvm.Picture != null)
                {
                    filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(pvm.Picture.FileName));
                    pvm.Picture.SaveAs(Server.MapPath(filePath));

                    Product p = new Product
                    {
                        ProductID = pvm.ProductID,
                        Name = pvm.Name,
                      
                        CategoryID = pvm.CategoryID,
                        SubCategoryID = pvm.SubCategoryID,
                        UnitPrice = pvm.UnitPrice,
                        OldPrice = pvm.OldPrice,
                     
                        UnitInStock = pvm.UnitInStock,
                        
                        ShortDescription = pvm.ShortDescription,
                       
                        PicturePath = filePath
                    };
                    db.Entry(p).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Product p = new Product
                    {
                        ProductID = pvm.ProductID,
                        Name = pvm.Name,
                      
                        CategoryID = pvm.CategoryID,
                        SubCategoryID = pvm.SubCategoryID,
                        UnitPrice = pvm.UnitPrice,
                        OldPrice = pvm.OldPrice,
                      
                        UnitInStock = pvm.UnitInStock,
                      
                        ShortDescription = pvm.ShortDescription,
                       
                        PicturePath = filePath
                    };
                    db.Entry(p).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
           
            ViewBag.categoryList = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.SubCategoryList = new SelectList(db.SubCategories, "SubCategoryID", "Name");
            return PartialView(pvm);
        }


        // DELETE: Product

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            Product product = db.Products.Find(id);
            string file_name = product.PicturePath;
            string path = Server.MapPath(file_name);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}