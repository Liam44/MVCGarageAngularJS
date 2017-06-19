using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAlongAJAX.Controllers
{
    public class VehicleTypesController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        // GET: VehicleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: VehicleTypes/Details/5
        public ActionResult Details(int? id)
        {
            return View(id);
        }

        // GET: VehicleTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(id);
        }

        // GET: VehicleTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            return View(id);
        }
    }
}
