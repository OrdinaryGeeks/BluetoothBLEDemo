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
    public class DescriptorsApiController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/DescriptorsApi
        public IQueryable<Descriptor> GetDescriptors()
        {
            return db.Descriptors;
        }

        // GET: api/DescriptorsApi/5
        [ResponseType(typeof(Descriptor))]
        public IHttpActionResult GetDescriptor(int id)
        {
            Descriptor descriptor = db.Descriptors.Find(id);
            if (descriptor == null)
            {
                return NotFound();
            }

            return Ok(descriptor);
        }

        // PUT: api/DescriptorsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDescriptor(int id, Descriptor descriptor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != descriptor.ID)
            {
                return BadRequest();
            }

            db.Entry(descriptor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescriptorExists(id))
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

        // POST: api/DescriptorsApi
        [ResponseType(typeof(Descriptor))]
        public IHttpActionResult PostDescriptor(Descriptor descriptor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Descriptors.Add(descriptor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = descriptor.ID }, descriptor);
        }

        // DELETE: api/DescriptorsApi/5
        [ResponseType(typeof(Descriptor))]
        public IHttpActionResult DeleteDescriptor(int id)
        {
            Descriptor descriptor = db.Descriptors.Find(id);
            if (descriptor == null)
            {
                return NotFound();
            }

            db.Descriptors.Remove(descriptor);
            db.SaveChanges();

            return Ok(descriptor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DescriptorExists(int id)
        {
            return db.Descriptors.Count(e => e.ID == id) > 0;
        }
    }
}