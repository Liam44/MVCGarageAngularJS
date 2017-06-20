using MVCGarageAngularJS.Models;
using MVCGarageAngularJS.Repositories;
using MVCGarageAngularJS.ViewModels.ParkingSpots;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace MVCGarageAngularJS.Controllers
{
    public class ParkingSpotsAPIController : ApiController
    {
        private ParkingSpotsRepository db = new ParkingSpotsRepository();

        // GET: api/ParkingSpotsAPI
        public IEnumerable<ParkingSpot> GetParkingSpots()
        {
            return db.ParkingSpots();
        }

        // GET: api/ParkingSpotsAPI
        public SelectAParkingSpotVM GetAvailableParkingSpots(int vehicleId, bool checkIn)
        {
            return new SelectAParkingSpotVM
            {
                ParkingSpots = new CheckInsParkingSpots().AvailableParkingSpots(),
                CheckIn = checkIn,
                SelectedVehicle = new VehiclesAPIController().Vehicle(vehicleId)
            };
        }

        // GET: api/ParkingSpotsAPI/5
        [ResponseType(typeof(ParkingSpot))]
        public IHttpActionResult Get(int id)
        {
            ParkingSpot parkingSpot = db.ParkingSpot(id);
            if (parkingSpot == null)
            {
                return NotFound();
            }

            return Ok(parkingSpot);
        }

        // PUT: api/ParkingSpotsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, ParkingSpot parkingSpot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parkingSpot.ID)
            {
                return BadRequest();
            }

            if (db.ParkingSpot(parkingSpot.Label) != null)
            {
                return Conflict();
            }

            db.Edit(parkingSpot);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ParkingSpotsAPI
        [ResponseType(typeof(ParkingSpot))]
        public IHttpActionResult Post(ParkingSpot parkingSpot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (db.ParkingSpot(parkingSpot.Label) != null)
            {
                return Conflict();
            }

            db.Add(parkingSpot);

            return CreatedAtRoute("DefaultApi", new { id = parkingSpot.ID }, parkingSpot);
        }

        // DELETE: api/ParkingSpotsAPI/5
        [ResponseType(typeof(ParkingSpot))]
        public IHttpActionResult Delete(int id)
        {
            ParkingSpot parkingSpot = db.ParkingSpot(id);
            if (parkingSpot == null)
            {
                return NotFound();
            }

            db.Delete(id);

            return Ok(parkingSpot);
        }

        public IHttpActionResult SelectAParkingSpot(int vehicleId, int parkingSpotId)
        {
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