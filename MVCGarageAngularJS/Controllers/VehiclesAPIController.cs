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
using Newtonsoft.Json;

namespace MVCGarageAngularJS.Controllers
{
    public class VehiclesAPIController : ApiController
    {
        private VehiclesRepository db = new VehiclesRepository();
        private OwnersRepository own = new OwnersRepository();
        private VehicleTypesRepository vtr = new VehicleTypesRepository();

        internal Vehicle Vehicle(int id)
        {
            Vehicle v = db.Vehicle(id);

            if (v != null)
              v.Owner = new OwnersAPIController().Owner(v.OwnerID);

            return v;
        }

        // GET: api/VehiclesControllerAPI
        public IEnumerable<Vehicle> Get()
        {
            return db.GetVehiclesWithOwners();
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
        [HttpPut]
        public HttpResponseMessage Put(int id, int ownerID, int vehicleTypeID, string regNum)
        {
            Vehicle v = db.Vehicle(id);
            Owner owner = own.Find(ownerID);
            VehicleType vehicleType = vtr.VehicleType(vehicleTypeID);

            if (v == null || v.ID == id)
            {
                v = db.Vehicle(id);
                v.Owner = owner;
                v.VehicleType = vehicleType;
                v.RegistrationPlate = regNum;

                db.Edit(v);
                return Request.CreateResponse(HttpStatusCode.OK, "This works");
            }
            else 
                return Request.CreateResponse(HttpStatusCode.Conflict, "Cannot edit Vehicle");
        }

        // POST: api/VehiclesControllerAPI
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult Post(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vehicle.RegistrationPlate = vehicle.RegistrationPlate.ToUpper();
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