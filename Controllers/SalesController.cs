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
    public class SalesController : Controller
    {
        private PharmacyDatabaseEntities db = new PharmacyDatabaseEntities();

        // GET: Sales
        public ActionResult Index()
        {
            var tblSales = db.tblSales.Include(t => t.tblCustomer);
            return View(tblSales.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSale tblSale = db.tblSales.Find(id);
            if (tblSale == null)
            {
                return HttpNotFound();
            }
            return View(tblSale);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.tblCustomers, "CustomerID", "FirstName");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesID,CustomerID,SalesNumber,SalesDate,FinalTotal")] tblSale tblSale)
        {
            if (ModelState.IsValid)
            {
                db.tblSales.Add(tblSale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.tblCustomers, "CustomerID", "FirstName", tblSale.CustomerID);
            return View(tblSale);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSale tblSale = db.tblSales.Find(id);
            if (tblSale == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.tblCustomers, "CustomerID", "FirstName", tblSale.CustomerID);
            return View(tblSale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesID,CustomerID,SalesNumber,SalesDate,FinalTotal")] tblSale tblSale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.tblCustomers, "CustomerID", "FirstName", tblSale.CustomerID);
            return View(tblSale);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSale tblSale = db.tblSales.Find(id);
            if (tblSale == null)
            {
                return HttpNotFound();
            }
            return View(tblSale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSale tblSale = db.tblSales.Find(id);
            db.tblSales.Remove(tblSale);
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
