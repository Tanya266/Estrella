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
using EstrellaWebApi.Entities;
using EstrellaWebApi.Models;

namespace EstrellaWebApi.Controllers
{
    public class УслугиController : ApiController
    {
        private EstrellaEntities db = new EstrellaEntities();

        // GET: api/Услуги
        [ResponseType(typeof(List<ResponseService>))]
        public IHttpActionResult GetУслуги()
        {
            return Ok(db.Услуги.ToList().ConvertAll(p=> new ResponseService(p)));
        }

        // GET: api/Услуги/5
        [ResponseType(typeof(Услуги))]
        public IHttpActionResult GetУслуги(int id)
        {
            Услуги услуги = db.Услуги.Find(id);
            if (услуги == null)
            {
                return NotFound();
            }

            return Ok(услуги);
        }

        // PUT: api/Услуги/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutУслуги(int id, Услуги услуги)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != услуги.Id)
            {
                return BadRequest();
            }

            db.Entry(услуги).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!УслугиExists(id))
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

        // POST: api/Услуги
        [ResponseType(typeof(Услуги))]
        public IHttpActionResult PostУслуги(Услуги услуги)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Услуги.Add(услуги);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (УслугиExists(услуги.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = услуги.Id }, услуги);
        }

        // DELETE: api/Услуги/5
        [ResponseType(typeof(Услуги))]
        public IHttpActionResult DeleteУслуги(int id)
        {
            Услуги услуги = db.Услуги.Find(id);
            if (услуги == null)
            {
                return NotFound();
            }

            db.Услуги.Remove(услуги);
            db.SaveChanges();

            return Ok(услуги);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool УслугиExists(int id)
        {
            return db.Услуги.Count(e => e.Id == id) > 0;
        }
    }
}