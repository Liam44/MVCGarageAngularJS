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
    public class OwnersAPIController : ApiController
    {
        private OwnersRepository db = new OwnersRepository();

        // GET: api/OwnersAPI
        public IEnumerable<Owner> Get()
        {
            return db.GetAllOwners();
        }

        // GET: api/OwnersAPI/5
        [ResponseType(typeof(Owner))]
        public IHttpActionResult Get(int id)
        {
            Owner owner = db.Find(id);
            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }

        // PUT: api/OwnersAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOwner(int id, Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != owner.ID)
            {
                return BadRequest();
            }

            db.EditOwner(owner);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OwnersAPI
        [ResponseType(typeof(Owner))]
        public IHttpActionResult PostOwner(Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AddNewOwner(owner);
            

            return CreatedAtRoute("DefaultApi", new { id = owner.ID }, owner);
        }

        // DELETE: api/OwnersAPI/5
        [ResponseType(typeof(Owner))]
        public IHttpActionResult DeleteOwner(int id)
        {
            Owner owner = db.Find(id);
            if (owner == null)
            {
                return NotFound();
            }

            db.RemoveOwner(owner);
            
            return Ok(owner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OwnerExists(int id)
        {
            IEnumerable<Owner> Owners = db.GetAllOwners();
            return Owners.Count(e => e.ID == id) > 0;
        }
    }
}