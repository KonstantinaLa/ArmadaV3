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
    public class PlanetController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IUnitOfWork unitOfWork;

        public PlanetController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: api/Planet
        public IHttpActionResult GetPlanets()
        {
            var planets = unitOfWork.Planets.Get().Select(p => new
            {
                PlanetId = p.PlanetId,
                Name = p.Name,
                StarSystem = p.StarSystem,
                Missions = p.Missions.Select(m => new
                {
                    MissionId = m.MissionId,
                    Type = m.Type

                })

            }); 

            return Ok(planets);
        }

        // GET: api/Planet/5
        [ResponseType(typeof(Planet))]
        public IHttpActionResult GetPlanet(int id)
        {
            var planet = unitOfWork.Planets.FindById(id);

            if (planet == null) return NotFound();
            
            return Ok(new{Name = planet.Name,Type = planet.Type.ToString()});
        }

        // PUT: api/Planet/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlanet(int id, Planet planet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != planet.PlanetId)
            {
                return BadRequest();
            }

            db.Entry(planet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanetExists(id))
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

        // POST: api/Planet
        [ResponseType(typeof(Planet))]
        public IHttpActionResult PostPlanet(Planet planet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Planets.Add(planet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = planet.PlanetId }, planet);
        }

        // DELETE: api/Planet/5
        [ResponseType(typeof(Planet))]
        public IHttpActionResult DeletePlanet(int? id)
        {
            var planet = unitOfWork.Planets.FindById(id);

            if (planet == null) return NotFound();

            unitOfWork.Planets.Delete(planet);
            unitOfWork.Save();

            return Ok(planet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlanetExists(int id)
        {
            return db.Planets.Count(e => e.PlanetId == id) > 0;
        }
    }
}