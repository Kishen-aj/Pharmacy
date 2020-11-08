using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pharmacy.Models;

namespace Pharmacy.Repositories
{
    public class PaymentTypeRepository
    {
        private PharmacyDatabaseEntities objPharmacyDatabaseEntities;
        public PaymentTypeRepository()
        {
            objPharmacyDatabaseEntities = new PharmacyDatabaseEntities();
        }

        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objPharmacyDatabaseEntities.tblPaymentTypes
                                  select new SelectListItem()
                                  {
                                      Text = obj.PaymentType,
                                      Value = obj.PaymentTypeID.ToString(),
                                      Selected = true
                                  }).ToList();

            return objSelectListItems;

        }
    }
}