using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pharmacy.Models;

namespace Pharmacy.Repositories
{
    public class ItemRepository
    {
        private PharmacyDatabaseEntities objPharmacyDatabaseEntities;
        public ItemRepository()
        {
            objPharmacyDatabaseEntities = new PharmacyDatabaseEntities();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objPharmacyDatabaseEntities.tblMedications
                                  select new SelectListItem()
                                  {
                                      Text = obj.ItemName,
                                      Value = obj.ItemID.ToString(),
                                      Selected = false
                                  }).ToList();

            return objSelectListItems;

        }
    }
}