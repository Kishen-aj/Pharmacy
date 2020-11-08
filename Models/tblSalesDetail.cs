//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pharmacy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class tblSalesDetail
    {
        [Display(Name = "Sale Detail ID")]
        public int SalesDetailID { get; set; }
        [Display(Name = "Sales ID")]
        public Nullable<int> SalesID { get; set; }
        [Display(Name = "Item ID")]
        public Nullable<int> ItemID { get; set; }
        [Display(Name = "Unit Price")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> UnitPrice { get; set; }
        [Display(Name = "Quantity")]
        public Nullable<decimal> Quantity { get; set; }
        [Display(Name = "Discount")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Discount { get; set; }
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Total { get; set; }
    
        public virtual tblMedication tblMedication { get; set; }
        public virtual tblSale tblSale { get; set; }
    }
}
