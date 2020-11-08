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
    public class ChronicMedicationsController : Controller
    {
        private PharmacyDatabaseEntities db = new PharmacyDatabaseEntities();

        // GET: ChronicMedications
        public ActionResult Index()
        {
            return View(db.tblChronicMedications.ToList());
        }

        // GET: ChronicMedications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChronicMedication tblChronicMedication = db.tblChronicMedications.Find(id);
            if (tblChronicMedication == null)
            {
                return HttpNotFound();
            }
            return View(tblChronicMedication);
        }

        // GET: ChronicMedications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChronicMedications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemName,Dosage,Price,ExpiryDate,StockQuantity")] tblChronicMedication tblChronicMedication)
        {
            if (ModelState.IsValid)
            {
                db.tblChronicMedications.Add(tblChronicMedication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblChronicMedication);
        }

        // GET: ChronicMedications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChronicMedication tblChronicMedication = db.tblChronicMedications.Find(id);
            if (tblChronicMedication == null)
            {
                return HttpNotFound();
            }
            return View(tblChronicMedication);
        }

        // POST: ChronicMedications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,Dosage,Price,ExpiryDate,StockQuantity")] tblChronicMedication tblChronicMedication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblChronicMedication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblChronicMedication);
        }

        // GET: ChronicMedications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChronicMedication tblChronicMedication = db.tblChronicMedications.Find(id);
            if (tblChronicMedication == null)
            {
                return HttpNotFound();
            }
            return View(tblChronicMedication);
        }

        // POST: ChronicMedications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblChronicMedication tblChronicMedication = db.tblChronicMedications.Find(id);
            db.tblChronicMedications.Remove(tblChronicMedication);
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
