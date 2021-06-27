using System.Net;
using System.Web.Mvc;
using ArmadaV3.Entities;
using ArmadaV3.RepositoryService;

namespace Armada.WebApp.Controllers
{
    public class TestAdmiralsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public TestAdmiralsController()
        {
            unitOfWork = new UnitOfWork();
        }

      
        public ActionResult Index()
        {
            return View(unitOfWork.Admirals.Get());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admiral admiral = unitOfWork.Admirals.FindById(id);
            if (admiral == null)
            {
                return HttpNotFound();
            }
            return View(admiral);
        }

        public ActionResult Create()
        {
            ViewBag.AdmiralId = new SelectList(unitOfWork.Crew.Get(), "CrewId", "Specialty");
            ViewBag.EmpireId = new SelectList(unitOfWork.Empires.Get(), "EmpireId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdmiralId,Name,Age,EnlistmentDate,Photo,Description,Specialty,Species,EmpireId")] Admiral admiral)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Admirals.Create(admiral);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.AdmiralId = new SelectList(unitOfWork.Crew.Get(), "CrewId", "Specialty", admiral.AdmiralId);
            ViewBag.EmpireId = new SelectList(unitOfWork.Empires.Get(), "EmpireId", "Name", admiral.EmpireId);

            return View(admiral);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admiral admiral = unitOfWork.Admirals.FindById(id);
            if (admiral == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdmiralId = new SelectList(unitOfWork.Crew.Get(), "CrewId", "Specialty", admiral.AdmiralId);
            ViewBag.EmpireId = new SelectList(unitOfWork.Empires.Get(), "EmpireId", "Name", admiral.EmpireId);
            return View(admiral);
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdmiralId,Name,Age,EnlistmentDate,Photo,Description,Specialty,Species,EmpireId")] Admiral admiral)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Admirals.Edit(admiral);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.AdmiralId = new SelectList(unitOfWork.Crew.Get(), "CrewId", "Specialty", admiral.AdmiralId);
            ViewBag.EmpireId = new SelectList(unitOfWork.Empires.Get(), "EmpireId", "Name", admiral.EmpireId);
            return View(admiral);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admiral admiral = unitOfWork.Admirals.FindById(id);
            if (admiral == null)
            {
                return HttpNotFound();
            }
            return View(admiral);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admiral admiral = unitOfWork.Admirals.FindById(id);
            unitOfWork.Admirals.Delete(admiral);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
