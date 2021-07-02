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
    public class EmperorController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IUnitOfWork unitOfWork;

        public EmperorController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: api/Emperor
        public IHttpActionResult GetEmperors()
        {
            var emperor = unitOfWork.Emperors.Get().Select(e => new
            {
                EmperorId = e.EmperorId,
                Name = e.Name,
                Age = e.Age,
                Photo = e.Photo,
                Empire = e.Empire.Name
            });

            return Ok(emperor);
        }

        // GET: api/Emperor/5
        [ResponseType(typeof(Emperor))]
        public IHttpActionResult GetEmperor(int? id)
        {
            var emperor = unitOfWork.Emperors.FindById(id);

            if (emperor == null) return NotFound();

            return Ok(new{Description = emperor.Description});
        }

        // PUT: api/Emperor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmperor(int id, Emperor emperor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emperor.EmperorId)
            {
                return BadRequest();
            }

            db.Entry(emperor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmperorExists(id))
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

        // POST: api/Emperor
        [ResponseType(typeof(Emperor))]
        public IHttpActionResult PostEmperor(Emperor emperor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Emperors.Add(emperor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmperorExists(emperor.EmperorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = emperor.EmperorId }, emperor);
        }

        // DELETE: api/Emperor/5
        [ResponseType(typeof(Emperor))]
        public IHttpActionResult DeleteEmperor(int? id)
        {
            var emperor = unitOfWork.Emperors.FindById(id);

            if (emperor == null) return NotFound();

            unitOfWork.Emperors.Delete(emperor);
            unitOfWork.Save();

            return Ok(emperor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmperorExists(int id)
        {
            return db.Emperors.Count(e => e.EmperorId == id) > 0;
        }
    }
}