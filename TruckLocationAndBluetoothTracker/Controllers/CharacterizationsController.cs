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
    public class CharacterizationsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Characterizations
        public IQueryable<Characterization> GetCharacterizations()
        {
            return db.Characterizations;
        }

        // GET: api/Characterizations/5
        [ResponseType(typeof(Characterization))]
        public IHttpActionResult GetCharacterization(int id)
        {
            Characterization characterization = db.Characterizations.Find(id);
            if (characterization == null)
            {
                return NotFound();
            }

            return Ok(characterization);
        }

        // PUT: api/Characterizations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCharacterization(int id, Characterization characterization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != characterization.ID)
            {
                return BadRequest();
            }

            db.Entry(characterization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterizationExists(id))
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

        // POST: api/Characterizations
        [ResponseType(typeof(Characterization))]
        public IHttpActionResult PostCharacterization(Characterization characterization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Characterizations.Add(characterization);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = characterization.ID }, characterization);
        }

        // DELETE: api/Characterizations/5
        [ResponseType(typeof(Characterization))]
        public IHttpActionResult DeleteCharacterization(int id)
        {
            Characterization characterization = db.Characterizations.Find(id);
            if (characterization == null)
            {
                return NotFound();
            }

            db.Characterizations.Remove(characterization);
            db.SaveChanges();

            return Ok(characterization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharacterizationExists(int id)
        {
            return db.Characterizations.Count(e => e.ID == id) > 0;
        }
    }
}