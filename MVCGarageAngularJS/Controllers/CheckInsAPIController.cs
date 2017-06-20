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
    public class CheckInsAPIController : ApiController
    {
        private CheckInsRepository db = new CheckInsRepository();

        // GET: api/CheckInsAPI
        public IEnumerable<CheckIn> Get()
        {
            return db.CheckIns();
        }

        // GET: api/CheckInsAPI/5
        [ResponseType(typeof(CheckIn))]
        public IHttpActionResult Get(int id)
        {
            CheckIn checkIn = db.CheckIn(id);
            if (checkIn == null)
            {
                return NotFound();
            }

            return Ok(checkIn);
        }

        // PUT: api/CheckInsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, CheckIn checkIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != checkIn.ID)
            {
                return BadRequest();
            }

            db.Edit(checkIn);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CheckInsAPI
        [ResponseType(typeof(CheckIn))]
        public IHttpActionResult Post(CheckIn checkIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(checkIn);

            return CreatedAtRoute("DefaultApi", new { id = checkIn.ID }, checkIn);
        }

        public IHttpActionResult VehicleCheckedIn(int vehicleId, int parkingSpotId)
        {
            // Check that the vehicle isn't already parked/hasn't booked a place
            if (db.CheckInByVehicle(vehicleId) != null)
                return BadRequest("Already checked in vehicle!");

            Vehicle vehicle = new VehiclesAPIController().Vehicle(vehicleId);

            if (vehicle == null)
                return BadRequest("You must select a vehicle!");

            // Check in the vehicle ID to the parking spot
            ParkingSpot parkingSpot = new ParkingSpotsAPIController().ParkingSpot(parkingSpotId);

            if (parkingSpot == null)
                return BadRequest("You must select a parking spot!");

            CheckIn checkIn = db.CheckIn(vehicleId, parkingSpotId);
            checkIn.Vehicle = vehicle;
            checkIn.ParkingSpot = parkingSpot;

            // Displays the chosen parking spot
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}