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
                Admirals = e.Admirals.Select(a => new
                {
                    AdmiralId = a.AdmiralId,
                    Name = a.Name,
                    Species = a.Species.ToString()
                })

            }) ; 

            return Ok(empires);
        }

        // GET: api/Empire/5
        [ResponseType(typeof(Empire))]
        public IHttpActionResult GetEmpire(int? id)
        {
            var empire = unitOfWork.Empires.FindById(id);

            if (empire == null) return NotFound();

            return Ok(new{Emperor = empire.Emperor?.Name , Description = empire.Description});
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
        public IHttpActionResult DeleteEmpire(int? id)
        {
            Empire empire = unitOfWork.Empires.FindById(id);

            if (empire == null) return NotFound();

            unitOfWork.Empires.Delete(empire);
            unitOfWork.Save();

            return Ok(empire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpireExists(int id)
        {
            return db.Empires.Count(e => e.EmpireId == id) > 0;
        }
    }
}