using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArmadaV3.Database;
using ArmadaV3.Entities;
using ArmadaV3.RepositoryService;

namespace Armada.WebApp.Controllers
{
    public class TestAdmiralsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private readonly IUnitOfWork unitOfWork;
        public TestAdmiralsController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: TestAdmirals
        public ActionResult Index()
        {
            return View(unitOfWork.Admirals.Get());
        }

        // GET: TestAdmirals/Details/5
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

        // GET: TestAdmirals/Create
        public ActionResult Create()
        {
            ViewBag.AdmiralId = new SelectList(unitOfWork.Crew.Get(), "CrewId", "Specialty");
            //ViewBag.EmpireId = new SelectList(db.Empires, "EmpireId", "Name");
            return View();
        }

        // POST: TestAdmirals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
            //EmpireId = new SelectList(db.Empires, "EmpireId", "Name", admiral.EmpireId);
            return View(admiral);
        }

        // GET: TestAdmirals/Edit/5
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
            //ViewBag.EmpireId = new SelectList(db.Empires, "EmpireId", "Name", admiral.EmpireId);
            return View(admiral);
        }

        // POST: TestAdmirals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
            //ViewBag.EmpireId = new SelectList(db.Empires, "EmpireId", "Name", admiral.EmpireId);
            return View(admiral);
        }

        // GET: TestAdmirals/Delete/5
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

        // POST: TestAdmirals/Delete/5
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
