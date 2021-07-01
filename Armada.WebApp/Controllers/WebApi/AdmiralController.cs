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
    public class AdmiralController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IUnitOfWork unitOfWork;

        public AdmiralController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: api/Admiral
        public IHttpActionResult GetAdmirals()
        {
            

            var admirals = unitOfWork.Admirals.Get().Select(a => new
            {
                AdmiralId = a.AdmiralId,
                Name = a.Name,
                Age = a.Age,
                EnlistmentDate = a.EnlistmentDate,
                Photo = a.Photo,
                Description = a.Description,
                Emprire = a.Empire.Name,
                Crew = a.Crew.Number,
                Missions = a.AdmiralMissions.Select(m => new
                {
                    Mission = m.Mission.
                })
            });


            //new
            //{

            //    MisionId = m.MissionId
            //}
            return Ok(admirals);
        }

        // GET: api/Admiral/5
        [ResponseType(typeof(Admiral))]
        public IHttpActionResult GetAdmiral(int id)
        {
            Admiral admiral = db.Admirals.Find(id);
            if (admiral == null)
            {
                return NotFound();
            }

            return Ok(admiral);
        }

        // PUT: api/Admiral/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdmiral(int id, Admiral admiral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admiral.AdmiralId)
            {
                return BadRequest();
            }

            db.Entry(admiral).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdmiralExists(id))
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

        // POST: api/Admiral
        [ResponseType(typeof(Admiral))]
        public IHttpActionResult PostAdmiral(Admiral admiral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Admirals.Add(admiral);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = admiral.AdmiralId }, admiral);
        }

        // DELETE: api/Admiral/5
        [ResponseType(typeof(Admiral))]
        public IHttpActionResult DeleteAdmiral(int id)
        {
            Admiral admiral = db.Admirals.Find(id);
            if (admiral == null)
            {
                return NotFound();
            }

            db.Admirals.Remove(admiral);
            db.SaveChanges();

            return Ok(admiral);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdmiralExists(int id)
        {
            return db.Admirals.Count(e => e.AdmiralId == id) > 0;
        }
    }
}