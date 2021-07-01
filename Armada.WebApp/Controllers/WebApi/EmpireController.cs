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
using ArmadaV3.Database;
using ArmadaV3.Entities;
using ArmadaV3.RepositoryService;

namespace Armada.WebApp.Controllers.WebApi
{
    public class EmpireController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IUnitOfWork unitOfWork;

        public EmpireController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: api/Empire
        public IHttpActionResult GetEmpires()
        {
            var empires = unitOfWork.Empires.Get().Select(e => new
            {
                EmpireId = e.EmpireId,
                Name = e.Name,
                Trait = e.Trait,
                ControlledSystem = e.ControlledSystems,
                Photo = e.Photo,
                Description = e.Description,
                Emperor = e.Emperor?.Name,
                Admirals = e.Admirals.Select(a => new
                {
                    AdmiralId = a.AdmiralId,
                    Name = a.Name,
                    Species = a.Species
                })

            }) ; 

            return Ok(empires);
        }

        // GET: api/Empire/5
        [ResponseType(typeof(Empire))]
        public IHttpActionResult GetEmpire(int id)
        {
            Empire empire = db.Empires.Find(id);
            if (empire == null)
            {
                return NotFound();
            }

            return Ok(empire);
        }

        // PUT: api/Empire/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpire(int id, Empire empire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empire.EmpireId)
            {
                return BadRequest();
            }

            db.Entry(empire).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpireExists(id))
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

        // POST: api/Empire
        [ResponseType(typeof(Empire))]
        public IHttpActionResult PostEmpire(Empire empire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empires.Add(empire);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empire.EmpireId }, empire);
        }

        // DELETE: api/Empire/5
        [ResponseType(typeof(Empire))]
        public IHttpActionResult DeleteEmpire(int id)
        {
            Empire empire = db.Empires.Find(id);
            if (empire == null)
            {
                return NotFound();
            }

            db.Empires.Remove(empire);
            db.SaveChanges();

            return Ok(empire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpireExists(int id)
        {
            return db.Empires.Count(e => e.EmpireId == id) > 0;
        }
    }
}