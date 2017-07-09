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

namespace TimeSeriesCategories.Controllers
{
    public class CategoryNodesController : ApiController
    {
        private TimeSeriesDBContext db = new TimeSeriesDBContext();



        // GET: api/CategoryNodes
        public IQueryable<CategoryNode> GetCategories()
        {
            return db.Categories;
        }

        // GET: api/CategoryNodes/5
        [ResponseType(typeof(CategoryNode))]
        public IHttpActionResult GetCategoryNode(string id)
        {
            CategoryNode categoryNode = db.Categories.Find(id);
            if (categoryNode == null)
            {
                return NotFound();
            }

            return Ok(categoryNode);
        }

        // PUT: api/CategoryNodes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoryNode(string id, CategoryNode categoryNode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryNode.ID)
            {
                return BadRequest();
            }

            db.Entry(categoryNode).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryNodeExists(id))
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

        // POST: api/CategoryNodes
        [ResponseType(typeof(CategoryNode))]
        public IHttpActionResult PostCategoryNode(CategoryNode categoryNode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(categoryNode);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CategoryNodeExists(categoryNode.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = categoryNode.ID }, categoryNode);
        }

        // DELETE: api/CategoryNodes/5
        [ResponseType(typeof(CategoryNode))]
        public IHttpActionResult DeleteCategoryNode(string id)
        {
            CategoryNode categoryNode = db.Categories.Find(id);
            if (categoryNode == null)
            {
                return NotFound();
            }

            db.Categories.Remove(categoryNode);
            db.SaveChanges();

            return Ok(categoryNode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryNodeExists(string id)
        {
            return db.Categories.Count(e => e.ID == id) > 0;
        }
    }
}