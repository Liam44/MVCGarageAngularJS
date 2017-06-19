using MVCGarageAngularJS.Models;
using MVCGarageAngularJS.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace CodeAlongAJAX.Controllers
{
    public class VehicleTypesAPIController : ApiController
    {
        private VehicleTypesRepository db = new VehicleTypesRepository();
        
        // GET api/values
        public IEnumerable<VehicleType> Get()
        {
            return db.VehicleTypes();
        }

        // GET api/values/5
        public VehicleType Get(int id)
        {
            return db.VehicleType(id);
        }

        // POST api/values
        public void Post([FromBody]VehicleType value)
        {
            // Some data consolidation
            if (db.VehicleType(value.Type) != null)
            {
                // A vehicle type with the same type already exists in the data base
            }

            int test = value.Type.Length;
            db.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]VehicleType value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
