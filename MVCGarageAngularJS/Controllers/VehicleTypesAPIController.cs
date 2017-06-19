using MVCGarageAngularJS.Models;
using MVCGarageAngularJS.Repositories;
using System.Collections.Generic;
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
        public bool Post([FromBody]VehicleType value)
        {
            // Some data consolidation
            if (db.VehicleType(value.Type) != null)
            {
                // A vehicle type with the same type already exists in the data base
                return false;
            }
            else
            {
                db.Add(value);

                return true;
            }
        }

        // PUT api/vehicleType/5
        public void Put(int id, [FromBody]VehicleType value)
        {
        }

        // DELETE api/vehicleType/5
        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}
