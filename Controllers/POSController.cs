using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pharmacy.Models;
using Pharmacy.ViewModel;
using Pharmacy.Repositories;

namespace Pharmacy.Controllers
{
    public class POSController : Controller
    {
        private PharmacyDatabaseEntities objPharmacyDatabaseEntities;
        public POSController()
        {
            objPharmacyDatabaseEntities = new PharmacyDatabaseEntities();
        }
        public ActionResult Index()
        {

            CustomerRepository objCustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository();


            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (objCustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentTypeRepository.GetAllPaymentType());


            return View(objMultipleModels);
        }
        [HttpGet]
        public JsonResult getItemUnitPrice(int ItemID)
        {
            decimal UnitPrice = Convert.ToDecimal(objPharmacyDatabaseEntities.tblMedications.Single(model => model.ItemID == ItemID).Price);
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Index(SalesViewModel objSalesViewModel)
        {
            SalesRepository objSalesRepository = new SalesRepository();
            objSalesRepository.AddSales(objSalesViewModel);

            return Json("Your Sale has been Successfully Created!", JsonRequestBehavior.AllowGet);
        }
    }
}