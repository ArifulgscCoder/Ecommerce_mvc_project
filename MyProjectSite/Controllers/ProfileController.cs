using MyProjectSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectSite.Controllers
{
    public class ProfileController : Controller
    {
        MyAppDBContext db = new MyAppDBContext();
        // GET: Profile
        public ActionResult Index()
        {
            return View(db.adminEmployees.Find(TemData.EmpID));
        }
    }
}