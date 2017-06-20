using MVCGarageAngularJS.ViewModels.ParkingSpots;
using System.Web.Mvc;

namespace MVCGarageAngularJS.Controllers
{
    public class ParkingSpotsController : Controller
    {
        public ActionResult Index()
        {
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

        [HttpGet]
        public ActionResult SelectAParkingSpot(int? vehicleId, bool checkIn)
        {
            if (vehicleId == null)
                vehicleId = 1;

            // Allows the user to select an available parking spot (if any), depending on the type of vehicle
            return View(new SelectAParkingSpotVM
            {
                SelectedVehicle = new VehiclesAPIController().Vehicle((int)vehicleId),
                CheckIn = checkIn
            });
        }
    }
}
