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
    public class MissionController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IUnitOfWork unitOfWork;

        public MissionController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: api/Mission
        public  IHttpActionResult GetMissions()
        {
            var missions = unitOfWork.Missions.Get().Select( m => new
            { 
                MissionId = m.MissionId,
                Type = m.Type,
                StartDate = m.StartDate,
                EndDate = m.EndDate,
                Planets = m.Planets.Select( y => new 
                { 
                    PlanetId = y.PlanetId,
                    Name = y.Name,
                    StarSystem = y.StarSystem
                }),
                Admirals = m.AdmiralMissions.Join(unitOfWork.Admirals.Get(), ad=>ad.AdmiralId, x=>x.AdmiralId,(ad,x) => new 
                { 
                    AdmiralId = x.AdmiralId,
                    Name = x.Name

                })
            });

            return Ok(missions);
        }

        // GET: api/Mission/5
        [ResponseType(typeof(Mission))]
        public IHttpActionResult GetMission(int id)
        {
            Mission mission = db.Missions.Find(id);
            if (mission == null)
            {
                return NotFound();
            }

            return Ok(mission);
        }

        // PUT: api/Mission/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMission(int id, Mission mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mission.MissionId)
            {
                return BadRequest();
            }

            db.Entry(mission).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(id))
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

        // POST: api/Mission
        [ResponseType(typeof(Mission))]
        public IHttpActionResult PostMission(Mission mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Missions.Add(mission);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mission.MissionId }, mission);
        }

        // DELETE: api/Mission/5
        [ResponseType(typeof(Mission))]
        public IHttpActionResult DeleteMission(int id)
        {
            Mission mission = db.Missions.Find(id);
            if (mission == null)
            {
                return NotFound();
            }

            db.Missions.Remove(mission);
            db.SaveChanges();

            return Ok(mission);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MissionExists(int id)
        {
            return db.Missions.Count(e => e.MissionId == id) > 0;
        }
    }
}