using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy.ViewModel
{
    public class SalesViewModel
    {
        public int SalesID { get; set; }
        public int CustomerID { get; set; }
        public string SalesNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal FinalTotal { get; set; }

        public IEnumerable<SalesDetailViewModel> ListOfSalesDetailViewModel { get; set; }

    }
}