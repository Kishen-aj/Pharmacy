using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Pharmacy.Models;

namespace Pharmacy.Controllers
{
    public class AccountController : Controller
    {
        PharmacyDatabaseEntities db = new PharmacyDatabaseEntities();
        // GET: Account
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(tblUser u)
        {
            if (ModelState.IsValid)
            {
                db.tblUsers.Add(u);
                if (db.SaveChanges()>0)
                {
                    return RedirectToAction("Index","Users");
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult Login(tblUser u)
        {
            if (ModelState.IsValid)
            {
                var user = db.tblUsers.Where(x => x.Username == u.Username && x.Password == u.Password && x.Role == u.Role).FirstOrDefault();
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(u.Username, false);
                    Session["Username"] = u.Username.ToString();
                    FormsAuthentication.SetAuthCookie(u.Role, false);
                    Session["Role"] = u.Role.ToString();
                    return RedirectToAction("Index","Home");
                }
                if (user == null)
                {
                    u.LoginError = "Invalid User!";
                    return View("Login", u);
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}