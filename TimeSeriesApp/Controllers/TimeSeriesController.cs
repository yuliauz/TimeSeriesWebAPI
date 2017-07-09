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
using TimeSeriesApp.Models;

namespace TimeSeriesApp.Controllers
{
    public class TimeSeriesController : ApiController
    {
        private TimeSeriesDBEntities1 db = new TimeSeriesDBEntities1();

        // GET: api/TimeSeries
        public IQueryable<TimeSery> GetTimeSeries()
        {
            return db.TimeSeries;
        }

        // GET: api/TimeSeries/5
        [ResponseType(typeof(TimeSery))]
        public IHttpActionResult GetTimeSery(int id)
        {
            TimeSery timeSery = db.TimeSeries.Find(id);
            if (timeSery == null)
            {
                return NotFound();
            }

            return Ok(timeSery);
        }

        // PUT: api/TimeSeries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTimeSery(int id, TimeSery timeSery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timeSery.Id)
            {
                return BadRequest();
            }

            db.Entry(timeSery).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeSeryExists(id))
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

        // POST: api/TimeSeries
        [ResponseType(typeof(TimeSery))]
        public IHttpActionResult PostTimeSery(TimeSery timeSery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TimeSeries.Add(timeSery);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TimeSeryExists(timeSery.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = timeSery.Id }, timeSery);
        }

        // DELETE: api/TimeSeries/5
        [ResponseType(typeof(TimeSery))]
        public IHttpActionResult DeleteTimeSery(int id)
        {
            TimeSery timeSery = db.TimeSeries.Find(id);
            if (timeSery == null)
            {
                return NotFound();
            }

            db.TimeSeries.Remove(timeSery);
            db.SaveChanges();

            return Ok(timeSery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeSeryExists(int id)
        {
            return db.TimeSeries.Count(e => e.Id == id) > 0;
        }
    }
}