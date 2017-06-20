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
    public class GarageAPIController : ApiController
    {
        private GarageContext db = new GarageContext();

        // GET: api/GarageAPI
        public IQueryable<ParkingSpot> GetParkingSpots()
        {
            return db.ParkingSpots;
        }

        // GET: api/GarageAPI/5
        [ResponseType(typeof(ParkingSpot))]
        public async Task<IHttpActionResult> GetParkingSpot(int id)
        {
            ParkingSpot parkingSpot = await db.ParkingSpots.FindAsync(id);
            if (parkingSpot == null)
            {
                return NotFound();
            }

            return Ok(parkingSpot);
        }

        // PUT: api/GarageAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutParkingSpot(int id, ParkingSpot parkingSpot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parkingSpot.ID)
            {
                return BadRequest();
            }

            db.Entry(parkingSpot).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingSpotExists(id))
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

        // POST: api/GarageAPI
        [ResponseType(typeof(ParkingSpot))]
        public async Task<IHttpActionResult> PostParkingSpot(ParkingSpot parkingSpot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParkingSpots.Add(parkingSpot);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = parkingSpot.ID }, parkingSpot);
        }

        // DELETE: api/GarageAPI/5
        [ResponseType(typeof(ParkingSpot))]
        public async Task<IHttpActionResult> DeleteParkingSpot(int id)
        {
            ParkingSpot parkingSpot = await db.ParkingSpots.FindAsync(id);
            if (parkingSpot == null)
            {
                return NotFound();
            }

            db.ParkingSpots.Remove(parkingSpot);
            await db.SaveChangesAsync();

            return Ok(parkingSpot);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParkingSpotExists(int id)
        {
            return db.ParkingSpots.Count(e => e.ID == id) > 0;
        }
    }
}