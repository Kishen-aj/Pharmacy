﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pharmacy.Models;

namespace Pharmacy.Controllers
{
    public class PatientsController : Controller
    {
        private PharmacyDatabaseEntities db = new PharmacyDatabaseEntities();

        // GET: Patients
        public ActionResult Index()
        {
            var tblPatients = db.tblPatients.Include(t => t.tblChronicMedication);
            return View(tblPatients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPatient tblPatient = db.tblPatients.Find(id);
            if (tblPatient == null)
            {
                return HttpNotFound();
            }
            return View(tblPatient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag.ChronicMedication = new SelectList(db.tblChronicMedications, "ItemID", "ItemName");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,FirstName,LastName,Email,CellNumber,Address,ChronicMedication,RepeatScript,DeliveryRequired,Hospital")] tblPatient tblPatient)
        {
            if (ModelState.IsValid)
            {
                db.tblPatients.Add(tblPatient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChronicMedication = new SelectList(db.tblChronicMedications, "ItemID", "ItemName", tblPatient.ChronicMedication);
            return View(tblPatient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPatient tblPatient = db.tblPatients.Find(id);
            if (tblPatient == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChronicMedication = new SelectList(db.tblChronicMedications, "ItemID", "ItemName", tblPatient.ChronicMedication);
            return View(tblPatient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientID,FirstName,LastName,Email,CellNumber,Address,ChronicMedication,RepeatScript,DeliveryRequired,Hospital")] tblPatient tblPatient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPatient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChronicMedication = new SelectList(db.tblChronicMedications, "ItemID", "ItemName", tblPatient.ChronicMedication);
            return View(tblPatient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPatient tblPatient = db.tblPatients.Find(id);
            if (tblPatient == null)
            {
                return HttpNotFound();
            }
            return View(tblPatient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPatient tblPatient = db.tblPatients.Find(id);
            db.tblPatients.Remove(tblPatient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
