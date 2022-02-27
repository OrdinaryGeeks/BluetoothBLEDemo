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
using TruckLocationAndBluetoothTracker.Models;

namespace TruckLocationAndBluetoothTracker.Controllers
{
    public class BLEBasesApiController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/BLEBasesApi
        public IQueryable<BLEBase> GetBLEBases()
        {
            return db.BLEBases;
        }

        // GET: api/BLEBasesApi/5
        [ResponseType(typeof(BLEBase))]
        public IHttpActionResult GetBLEBase(int id)
        {
            BLEBase bLEBase = db.BLEBases.Find(id);
            if (bLEBase == null)
            {
                return NotFound();
            }

            return Ok(bLEBase);
        }

        // PUT: api/BLEBasesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBLEBase(int id, BLEBase bLEBase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bLEBase.ID)
            {
                return BadRequest();
            }

            db.Entry(bLEBase).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BLEBaseExists(id))
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

        // POST: api/BLEBasesApi
        [ResponseType(typeof(BLEBase))]
        public IHttpActionResult PostBLEBase(BLEBase bLEBase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BLEBases.Add(bLEBase);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bLEBase.ID }, bLEBase);
        }

        // DELETE: api/BLEBasesApi/5
        [ResponseType(typeof(BLEBase))]
        public IHttpActionResult DeleteBLEBase(int id)
        {
            BLEBase bLEBase = db.BLEBases.Find(id);
            if (bLEBase == null)
            {
                return NotFound();
            }

            db.BLEBases.Remove(bLEBase);
            db.SaveChanges();

            return Ok(bLEBase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BLEBaseExists(int id)
        {
            return db.BLEBases.Count(e => e.ID == id) > 0;
        }
    }
}