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
            var admirals =unitOfWork.Admirals.Get().Select(a => new
            {
                AdmiralId = a.AdmiralId,
                Name = a.Name,
                Age = a.Age,
                EnlistmentDate = a.EnlistmentDate.ToString("d"),
                Photo = a.Photo,
                Description = a.Description,
                Crew = a.Crew?.Number,
                Missions = a.AdmiralMissions.Join(unitOfWork.Missions.Get(), ad=>ad.MissionId , m=>m.MissionId ,(ad ,m )=> new
                {
                    MissionId = m.MissionId,
                    Type = m.Type,
                    StartDate = m.StartDate.ToString("d"),
                    IsSuccess = ad.IsSuccess
                })
               
            });

            return Ok(admirals);
        }

        // GET: api/Admiral/5
        [ResponseType(typeof(Admiral))]
        public IHttpActionResult GetAdmiral(int id)
        {
            var admiral = unitOfWork.Admirals.FindById(id);
            if (admiral == null)
            {
                return NotFound();
            }

            return Ok(new { EnlistmentDate = admiral.EnlistmentDate.ToString("d"), Empire = admiral.Empire.Name, Description = admiral.Description });
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
        public IHttpActionResult DeleteAdmiral(int? id)
        {
            var admiral = unitOfWork.Admirals.FindById(id);
            if (admiral == null) return NotFound();

            unitOfWork.Admirals.Delete(admiral);
            unitOfWork.Save();

            return Ok(admiral);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdmiralExists(int id)
        {
            return db.Admirals.Count(e => e.AdmiralId == id) > 0;
        }
    }
}