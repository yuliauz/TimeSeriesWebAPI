using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Test.Models;

namespace Test.Controllers
{
    public class TimeSeriesController : ApiController
    {
        private TSDBEntities db = new TSDBEntities();

        [HttpGet]
        public List<Category> Categories()
        {
            return db.Categories.ToList();
        }       

        [HttpGet]
        public List<TimePeriod> TimePeriods()
        {
            return db.TimePeriods.ToList();
        }
          
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}