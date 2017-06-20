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

namespace MVCGarageAngularJS.Controllers
{
    public class CheckInsController : Controller
    {
        // GET: CheckIns
        public ActionResult Index()
        {
            return View();
        }

        // GET: CheckIns/Details/5
        public ActionResult Details(int? id)
        {
            return View(id);
        }

        // GET: CheckIns/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: CheckIns/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(id);
        }

        // GET: CheckIns/Delete/5
        public ActionResult Delete(int? id)
        {
            return View(id);
        }
    }
}
