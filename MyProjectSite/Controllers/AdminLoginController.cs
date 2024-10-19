using MyProjectSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectSite.Controllers
{
    public class AdminLoginController : Controller
    {
        MyAppDBContext db = new MyAppDBContext();
        // GET: admin_Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminLogin login)
        {
            if (ModelState.IsValid)
            {
                var model = (from m in db.adminLogins
                             where m.UserName == login.UserName && m.Password == login.Password
                             select m).Any();

                if (model)
                {
                    var loginInfo = db.adminLogins.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();

                    Session["username"] = loginInfo.UserName;
                    TemData.EmpID= loginInfo.EmpID;
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return RedirectToAction("Index", "AdminLogin");
        }
        // Logout Server Code
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}