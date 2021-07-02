using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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
                Duration = m.Duration,
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
        public IHttpActionResult GetMission(int? id)
        {
            var mission = unitOfWork.Missions.FindById(id);

            if (mission == null) return NotFound();
           
            return Ok(new
            {
                StartDate = mission.StartDate.ToString("d"),
                EndDate = mission.EndDate.ToString("d"),
            });
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
        public IHttpActionResult DeleteMission(int? id)
        {
            var mission = unitOfWork.Missions.FindById(id);

            if (mission == null) return NotFound();

            unitOfWork.Missions.Delete(mission);
            unitOfWork.Save();

            return Ok(mission);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MissionExists(int id)
        {
            return db.Missions.Count(e => e.MissionId == id) > 0;
        }
    }
}