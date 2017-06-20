using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MVCGarageAngularJS.DataAccess;
using MVCGarageAngularJS.Models;
using MVCGarageAngularJS.Repositories;

namespace MVCGarageAngularJS.Controllers
{
    public class GarageAPIController : ApiController
    {
        private ParkingSpotsRepository parkingSpots = new ParkingSpotsRepository();
        private VehiclesRepository vehicles = new VehiclesRepository();
        private CheckInsRepository checkIns = new CheckInsRepository();

        // GET: api/GarageAPI
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return vehicles.GetVehiclesWithOwners();
        }

        // GET: api/GarageAPI
        public IEnumerable<Vehicle> GetParkedVehicles()
        {
            List<Vehicle> parkedVehicles = new List<Vehicle>();

            foreach (Vehicle vehicle in vehicles.Vehicles())
            {
                CheckIn checkIn = checkIns.CheckInByVehicle(vehicle.ID);

                if (checkIn != null)
                {
                    parkedVehicles.Add(vehicle);
                }
            }

            return parkedVehicles;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                vehicles.Dispose();
                parkingSpots.Dispose();
                checkIns.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}