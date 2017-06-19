using MVCGarageAngularJS.Models;
using MVCGarageAngularJS.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeAlongAJAX.Controllers
{
    public class VehicleTypesAPIController : ApiController
    {
        private VehicleTypesRepository db = new VehicleTypesRepository();

        // GET api/vehicleType
        public IEnumerable<VehicleType> Get()
        {
            return db.VehicleTypes();
        }

        // GET api/vehicleType/5
        public VehicleType Get(int id)
        {
            return db.VehicleType(id);
        }

        // POST api/vehicleType
        public HttpResponseMessage Post([FromBody]VehicleType value)
        {
            // Some data consolidation
            if (db.VehicleType(value.Type) != null)
            {
                // A vehicle type with the same type already exists in the data base
                var response = Request.CreateErrorResponse(HttpStatusCode.Conflict, "The vehicle type already exists");
                response.Headers.Location = new Uri("http://www.google.com");
                return response;
            }
            else
            {
                db.Add(value);

                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
        }

        // PUT api/vehicleType/5
        public HttpResponseMessage Put(int id, string type, double fee)
        {
            VehicleType vt = db.VehicleType(type);
            if (vt == null || vt.ID == id)
            {
                vt = db.VehicleType(id);
                vt.Type = type;
                vt.Fee = fee;

                db.Edit(vt);

                string msg = "Updated: Type: " + type +
                    " | Fee: " + fee;

                return Request.CreateResponse(HttpStatusCode.OK, msg);
            }
            else
                return Request.CreateResponse(HttpStatusCode.Conflict, "An identical vehicle type already exists");
        }

        // DELETE api/vehicleType/5
        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}
