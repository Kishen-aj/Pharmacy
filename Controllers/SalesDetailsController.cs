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
    public class SalesDetailsController : Controller
    {
        private PharmacyDatabaseEntities db = new PharmacyDatabaseEntities();

        // GET: SalesDetails
        public ActionResult Index()
        {
            var tblSalesDetails = db.tblSalesDetails.Include(t => t.tblMedication).Include(t => t.tblSale);
            return View(tblSalesDetails.ToList());
        }

        // GET: SalesDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSalesDetail tblSalesDetail = db.tblSalesDetails.Find(id);
            if (tblSalesDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblSalesDetail);
        }

        // GET: SalesDetails/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.tblMedications, "ItemID", "ItemName");
            ViewBag.SalesID = new SelectList(db.tblSales, "SalesID", "SalesNumber");
            return View();
        }

        // POST: SalesDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesDetailID,SalesID,ItemID,UnitPrice,Quantity,Discount,Total")] tblSalesDetail tblSalesDetail)
        {
            if (ModelState.IsValid)
            {
                db.tblSalesDetails.Add(tblSalesDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.tblMedications, "ItemID", "ItemName", tblSalesDetail.ItemID);
            ViewBag.SalesID = new SelectList(db.tblSales, "SalesID", "SalesNumber", tblSalesDetail.SalesID);
            return View(tblSalesDetail);
        }

        // GET: SalesDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSalesDetail tblSalesDetail = db.tblSalesDetails.Find(id);
            if (tblSalesDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.tblMedications, "ItemID", "ItemName", tblSalesDetail.ItemID);
            ViewBag.SalesID = new SelectList(db.tblSales, "SalesID", "SalesNumber", tblSalesDetail.SalesID);
            return View(tblSalesDetail);
        }

        // POST: SalesDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesDetailID,SalesID,ItemID,UnitPrice,Quantity,Discount,Total")] tblSalesDetail tblSalesDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSalesDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.tblMedications, "ItemID", "ItemName", tblSalesDetail.ItemID);
            ViewBag.SalesID = new SelectList(db.tblSales, "SalesID", "SalesNumber", tblSalesDetail.SalesID);
            return View(tblSalesDetail);
        }

        // GET: SalesDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSalesDetail tblSalesDetail = db.tblSalesDetails.Find(id);
            if (tblSalesDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblSalesDetail);
        }

        // POST: SalesDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSalesDetail tblSalesDetail = db.tblSalesDetails.Find(id);
            db.tblSalesDetails.Remove(tblSalesDetail);
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
