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
    public class TimeSerieController : ApiController
    {
        private TimeSeriesDBEntities1 db = new TimeSeriesDBEntities1();
        
        // GET: api/TimeSeries1
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return new string[]{ "a", "nb"};
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