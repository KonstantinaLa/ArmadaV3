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

    public class CrewController : ApiController
    {
       
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IUnitOfWork unitOfWork;

        public CrewController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: api/Crew
        public IHttpActionResult GetCrews()
        {
            //May need more Data for Admiral, Konstantina
            var crew = unitOfWork.Crew.Get().Select(c=>new
            {
                CrewId = c.CrewId,
                Number = c.Number,
                Specialty = c.Specialty,
                Admiral = c.Admiral.Name
            });

            return Ok(crew);
        }

        // GET: api/Crew/5
        [ResponseType(typeof(Crew))]
        public IHttpActionResult GetCrew(int? id)
        {
            var crew = unitOfWork.Crew.FindById(id);

            if (crew == null) return NotFound();

            return Ok(new {Crewid = crew.CrewId , Number = crew.Number , Specialty = crew.Specialty, Admiral = crew.Admiral.Name });
        }

        // PUT: api/Crew/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCrew(int id, Crew crew)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != crew.CrewId)
            {
                return BadRequest();
            }

            db.Entry(crew).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrewExists(id))
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

        // POST: api/Crew
        [ResponseType(typeof(Crew))]
        public IHttpActionResult PostCrew(Crew crew)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Crews.Add(crew);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CrewExists(crew.CrewId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = crew.CrewId }, crew);
        }

        // DELETE: api/Crew/5
        [ResponseType(typeof(Crew))]
        public IHttpActionResult DeleteCrew(int? id)
        {
            var crew = unitOfWork.Crew.FindById(id);

            if (crew == null) return NotFound();

            unitOfWork.Crew.Delete(crew);
            unitOfWork.Save();

            return Ok(crew);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CrewExists(int id)
        {
            return db.Crews.Count(e => e.CrewId == id) > 0;
        }
    }
}