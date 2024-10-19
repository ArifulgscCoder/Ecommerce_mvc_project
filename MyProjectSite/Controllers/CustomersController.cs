using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyProjectSite.Models;

namespace MyProjectSite.Controllers
{
    public class CustomerController : Controller
    {
        private MyAppDBContext db = new MyAppDBContext();

        // GET: Customer
        public ActionResult Index()
        {
            using (var context = new MyAppDBContext())
            {
                
                var customer = context.Customers.FirstOrDefault();

              
                var customers = new List<Customer> { customer };

                return View(customers);
            }
        }

        // CREATE: Customer
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                string filePath = string.Empty;

                if (cvm.Picture != null)
                {
                    filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(cvm.Picture.FileName));
                    cvm.Picture.SaveAs(Server.MapPath(filePath));
                }

                Customer customer = new Customer
                {
                    First_Name = cvm.First_Name,
                    Last_Name = cvm.Last_Name,
                    UserName = cvm.UserName,
                    Password = cvm.Password,
                    Gender = cvm.Gender,
                    DateofBirth = cvm.DateofBirth,
                    Country = cvm.Country,
                    City = cvm.City,
                    Email = cvm.Email,
                    Phone = cvm.Phone,
                    Address = cvm.Address,
                    PicturePath = filePath
                };

                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Login","Account");
            }

            return PartialView("_Error");
        }


        // EDIT: Customer
        public ActionResult Edit(int id)
        {
            Customer cus = db.Customers.Find(id);

            if (cus == null)
            {
                return HttpNotFound();
            }

            CustomerViewModel cvm = new CustomerViewModel
            {
                CustomerID = cus.CustomerID,
                First_Name = cus.First_Name,
                Last_Name = cus.Last_Name,
                UserName = cus.UserName,
                Password = cus.Password,
                Gender = cus.Gender,
                DateofBirth = cus.DateofBirth,
                Country = cus.Country,
                City = cus.City,
                Email = cus.Email,
                Phone = cus.Phone,
                Address = cus.Address,
                PicturePath = cus.PicturePath
            };

            return View(cvm);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                string filePath = cvm.PicturePath;

                if (cvm.Picture != null)
                {
                    filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(cvm.Picture.FileName));
                    cvm.Picture.SaveAs(Server.MapPath(filePath));
                }

                Customer customer = new Customer
                {
                    CustomerID = cvm.CustomerID,
                    First_Name = cvm.First_Name,
                    Last_Name = cvm.Last_Name,
                    UserName = cvm.UserName,
                    Password = cvm.Password,
                    Gender = cvm.Gender,
                    DateofBirth = cvm.DateofBirth,
                    Country = cvm.Country,
                    City = cvm.City,
                    Email = cvm.Email,
                    Phone = cvm.Phone,
                    Address = cvm.Address,
                    PicturePath = filePath
                };

                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cvm);
        }

        // DETAILS: Customer
        public ActionResult Details(int id)
        {
            Customer cus = db.Customers.Find(id);

            if (cus == null)
            {
                return HttpNotFound();
            }

            CustomerViewModel cvm = new CustomerViewModel
            {
                CustomerID = cus.CustomerID,
                First_Name = cus.First_Name,
                Last_Name = cus.Last_Name,
                UserName = cus.UserName,
                Password = cus.Password,
                Gender = cus.Gender,
                DateofBirth = cus.DateofBirth,
                Country = cus.Country,
                City = cus.City,
                Email = cus.Email,
                Phone = cus.Phone,
                Address = cus.Address,
                PicturePath = cus.PicturePath
            };

            return View(cvm);
        }

        // DELETE: Customer
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Customer customer = db.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer != null)
            {
                string filePath = customer.PicturePath;

                if (!string.IsNullOrEmpty(filePath))
                {
                    string path = Server.MapPath(filePath);
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }

                db.Customers.Remove(customer);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formColl)
        {
            string usrName = formColl["UserName"];
            string Pass = formColl["Password"];

            if (ModelState.IsValid)
            {
                var cust = (from m in db.Customers
                            where (m.UserName == usrName && m.Password == Pass)
                            select m).SingleOrDefault();

                if (cust != null)
                {
                    TempShopData.UserID = cust.CustomerID;
                    Session["username"] = cust.UserName;
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }

        //LOG OUT
        public ActionResult Logout()
        {
            Session["username"] = null;
            TempShopData.UserID = 0;
            TempShopData.items = null;
            return RedirectToAction("Index", "Home");
        }



        public Customer GetUser(string _usrName)
        {
            var cust = (from c in db.Customers
                        where c.UserName == _usrName
                        select c).FirstOrDefault();
            return cust;
        }
    }

}
