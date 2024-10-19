using MyProjectSite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectSite.Controllers
{
    public class AccountController : Controller
    {
        MyAppDBContext db = new MyAppDBContext();


        
        public ActionResult Index()
        {
            this.GetDefaultData();
            var usr = db.Customers.Find(TempShopData.UserID);
            var userList = new List<Customer> { usr };
            return View(userList);
        }



        //REGISTER CUSTOMER
        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(cust);
                db.SaveChanges();

                Session["username"] = cust.UserName;
                TempShopData.UserID = GetUser(cust.UserName).CustomerID;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }



        //LOG IN
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        
        public JsonResult Login(FormCollection formColl)
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
                    Session["username"] = cust.First_Name;
                    return Json(new { success = true, message = "Login successful!" });
                }
                else
                {
                    return Json(new { success = false, message = "Invalid username or password." });
                }
            }
            return Json(new { success = false, message = "Please fill in all required fields." });
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

        //UPDATE CUSTOMER DATA
        [HttpPost]
        public ActionResult Update(Customer cust)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cust).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Session["username"] = cust.UserName;
                return RedirectToAction("Index", "Home");
            }
            return View();
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
    }
}


