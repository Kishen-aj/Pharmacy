using System;
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
    public class MedicationsController : Controller
    {
        private PharmacyDatabaseEntities db = new PharmacyDatabaseEntities();

        // GET: Medications
        public ActionResult Index()
        {
            return View(db.tblMedications.ToList());
        }

        // GET: Medications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMedication tblMedication = db.tblMedications.Find(id);
            if (tblMedication == null)
            {
                return HttpNotFound();
            }
            return View(tblMedication);
        }

        // GET: Medications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemName,Dosage,Price,ExpiryDate,PrescriptionRequired,StockQuantity")] tblMedication tblMedication)
        {
            if (ModelState.IsValid)
            {
                db.tblMedications.Add(tblMedication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblMedication);
        }

        // GET: Medications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMedication tblMedication = db.tblMedications.Find(id);
            if (tblMedication == null)
            {
                return HttpNotFound();
            }
            return View(tblMedication);
        }

        // POST: Medications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,Dosage,Price,ExpiryDate,PrescriptionRequired,StockQuantity")] tblMedication tblMedication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMedication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblMedication);
        }

        // GET: Medications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMedication tblMedication = db.tblMedications.Find(id);
            if (tblMedication == null)
            {
                return HttpNotFound();
            }
            return View(tblMedication);
        }

        // POST: Medications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMedication tblMedication = db.tblMedications.Find(id);
            db.tblMedications.Remove(tblMedication);
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
