﻿using MyProjectSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectSite.Controllers
{
    public class CategoryController : Controller
    {
        MyAppDBContext db = new MyAppDBContext();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category ctg)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(ctg);
                db.SaveChanges();
                return PartialView("_Success");
            }
            return PartialView("_Error");
        }
    }
}