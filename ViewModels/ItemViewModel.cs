using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy.ViewModel
{
    public class ItemViewModel
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string Dosage { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string PrescriptionRequired { get; set; }
        public int StockQuantity { get; set; }

    }
}