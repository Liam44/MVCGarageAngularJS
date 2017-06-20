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

namespace MVCGarageAngularJS.Controllers
{
    public class CheckInsAPIController : ApiController
    {
        private GarageContext db = new GarageContext();

        // GET: api/CheckInsAPI
        public IQueryable<CheckIn> GetCheckIns()
        {
            return db.CheckIns;
        }

        // GET: api/CheckInsAPI/5
        [ResponseType(typeof(CheckIn))]
        public async Task<IHttpActionResult> GetCheckIn(int id)
        {
            CheckIn checkIn = await db.CheckIns.FindAsync(id);
            if (checkIn == null)
            {
                return NotFound();
            }

            return Ok(checkIn);
        }

        // PUT: api/CheckInsAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCheckIn(int id, CheckIn checkIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != checkIn.ID)
            {
                return BadRequest();
            }

            db.Entry(checkIn).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckInExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CheckInsAPI
        [ResponseType(typeof(CheckIn))]
        public async Task<IHttpActionResult> PostCheckIn(CheckIn checkIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CheckIns.Add(checkIn);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = checkIn.ID }, checkIn);
        }

        // DELETE: api/CheckInsAPI/5
        [ResponseType(typeof(CheckIn))]
        public async Task<IHttpActionResult> DeleteCheckIn(int id)
        {
            CheckIn checkIn = await db.CheckIns.FindAsync(id);
            if (checkIn == null)
            {
                return NotFound();
            }

            db.CheckIns.Remove(checkIn);
            await db.SaveChangesAsync();

            return Ok(checkIn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CheckInExists(int id)
        {
            return db.CheckIns.Count(e => e.ID == id) > 0;
        }
    }
}