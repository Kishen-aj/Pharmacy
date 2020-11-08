using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Pharmacy.Controllers
{
    public class ReminderController : Controller
    {
        PharmacyDatabaseEntities db = new PharmacyDatabaseEntities();
        // GET: Reminder
        public ActionResult Index()
        {
            return View();
        }
        // GET: Email
        public ActionResult SendEmail()
        {
            var items = db.tblPatients.ToList();
            if (items != null)
            {
                ViewBag.data = items;
            }

            return View(ViewBag.data);
        }

        [HttpPost]
        public ActionResult SendEmail(tblPatient q,string useremail, [Bind(Include = "PatientID,FirstName,LastName,Email,CellNumber,Address,ChronicMedication,RepeatScript,DeliveryRequired,Hospital")] tblPatient tblPatient)
        {
            PharmacyDatabaseEntities db = new PharmacyDatabaseEntities();
            string subject = "<do-not-reply> Reminder for Medication Pickup @ Ballantine's Pharmacy";
            string body = "Good day! Hope you are keeping well. This is a reminder from Ballantine's Pharmacy to collect medication for the month to follow. See you soon!";

            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 587;
            WebMail.SmtpUseDefaultCredentials = true;
            WebMail.EnableSsl = true;
            WebMail.UserName = "ballantines.pharmacy@gmail.com";
            WebMail.Password = "Ballantines2020";

            WebMail.Send(useremail, subject, body);
            ViewBag.msg = "Email sent!";
            return View(q);
        }
    }
}