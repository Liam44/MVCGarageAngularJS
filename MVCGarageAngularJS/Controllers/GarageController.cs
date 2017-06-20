using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCGarageAngularJS.Controllers
{
    public class GarageController : Controller
    {
        // GET: Garage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayAllVehicles()
        {
            return View();
        }
  
        public ActionResult DisplayParkedVehicles()
        {
            return View();
        }
  }
}