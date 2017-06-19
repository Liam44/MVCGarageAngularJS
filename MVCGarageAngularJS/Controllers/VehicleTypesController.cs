using MVCGarageAngularJS.Models;
using MVCGarageAngularJS.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace CodeAlongAJAX.Controllers
{
    public class VehicleTypesController : ApiController
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
            int test = value.Type.Length;
            //persons.Add(value);
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
