using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pharmacy.Models;
using Pharmacy.ViewModel;

namespace Pharmacy.Repositories
{
    public class SalesRepository
    {
        private PharmacyDatabaseEntities objPharmacyDatabaseEntities;

        public SalesRepository()
        {
            objPharmacyDatabaseEntities = new PharmacyDatabaseEntities();
        }

        public bool AddSales(SalesViewModel objSalesViewModel)
        {
            tblSale objSales = new tblSale();
            objSales.CustomerID = objSalesViewModel.CustomerID;
            objSales.FinalTotal = objSalesViewModel.FinalTotal;
            objSales.SalesDate = DateTime.Now;
            objSales.SalesNumber = String.Format("{0:ddmmyyyhhmmss}", DateTime.Now);
            objPharmacyDatabaseEntities.tblSales.Add(objSales);
            objPharmacyDatabaseEntities.SaveChanges();
            int SalesID = objSales.SalesID;

            foreach (var item in objSalesViewModel.ListOfSalesDetailViewModel)
            {
                tblSalesDetail objSalesDetail = new tblSalesDetail();
                objSalesDetail.SalesID = SalesID;
                objSalesDetail.Discount = item.Discount;
                objSalesDetail.ItemID = item.ItemID;
                objSalesDetail.Total = item.Total;
                objSalesDetail.UnitPrice = item.UnitPrice;
                objSalesDetail.Quantity = item.Quantity;
                objPharmacyDatabaseEntities.tblSalesDetails.Add(objSalesDetail);
                objPharmacyDatabaseEntities.SaveChanges();

                PharmacyDatabaseEntities db = new PharmacyDatabaseEntities();
                int MedID = item.ItemID;
                decimal StockAdj = item.Quantity;
                var query = from med in db.tblMedications where med.ItemID == MedID select med;
                
                foreach (tblMedication med in query)
                {
                    med.StockQuantity = (med.StockQuantity - Convert.ToInt32(StockAdj));
                }

                try
                {
                    db.SaveChanges();
                    MedID = 0;
                    StockAdj = 0;
                }

                catch (Exception e)
                {

                }
            }

            return true;
        }
    }
}