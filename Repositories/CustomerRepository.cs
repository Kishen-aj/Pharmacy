using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pharmacy.Models;

namespace Pharmacy.Repositories
{
    public class CustomerRepository
    {
        private PharmacyDatabaseEntities objPharmacyDatabaseEntities;
        public CustomerRepository()
        {
            objPharmacyDatabaseEntities = new PharmacyDatabaseEntities();
        }

        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objPharmacyDatabaseEntities.tblCustomers
                                  select new SelectListItem()
                                  {
                                      Text = obj.FirstName,
                                      Value = obj.CustomerID.ToString(),
                                      Selected = true
                                  }).ToList();

            return objSelectListItems;

        }
    }
}