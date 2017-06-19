using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCGarageAngularJS.DataAccess;
using MVCGarageAngularJS.Models;
using MVCGarageAngularJS.Repositories;

namespace MVCGarageAngularJS.Controllers
{
    public class VehiclesController : Controller
    {
        public ActionResult Index()
        { 
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Create()
        { 
            ViewBag.Title = "Create Page";

            return View();
        }

        public ActionResult Delete(int? id)
        {
            ViewBag.Title = "Delete Page";

            return View(id);
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit Page";

            return View(id);
        }

        public ActionResult Details(int? id)
        {
            ViewBag.Title = "Details Page";

            return View(id);
        }
    }
}
