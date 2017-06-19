using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVCGarageAngularJS.DataAccess;
using MVCGarageAngularJS.Models;
using MVCGarageAngularJS.Repositories;

namespace MVCGarageAngularJS.Controllers
{
    public class VehiclesAPIController : ApiController
    {
        private VehiclesRepository db = new VehiclesRepository();

        // GET: api/VehiclesControllerAPI
        public IEnumerable<Vehicle> Get()
        {
            return db.Vehicles();
        }

        // GET: api/VehiclesControllerAPI/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult Get(int id)
        {
            Vehicle vehicle = db.Vehicle(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        // PUT: api/VehiclesControllerAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicle(int id, Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicle.ID)
            {
                return BadRequest();
            }

            db.Edit(vehicle);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VehiclesControllerAPI
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult PostVehicle(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(vehicle);

            return CreatedAtRoute("DefaultApi", new { id = vehicle.ID }, vehicle);
        }

        // DELETE: api/VehiclesControllerAPI/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult DeleteVehicle(int id)
        {
            Vehicle vehicle = db.Vehicle(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            db.Remove(vehicle);

            return Ok(vehicle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleExists(int id)
        {
            IEnumerable<Vehicle> vehicles = db.Vehicles();
            return vehicles.Count(e => e.ID == id) > 0;
        }
    }
}