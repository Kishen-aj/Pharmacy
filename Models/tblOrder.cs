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
    public partial class tblOrder
    {
        [Display(Name = "OrderID")]
        public int OrderId { get; set; }
        [Display(Name = "Item Required")]
        public string ItemRequired { get; set; }
        [Display(Name = "Stock Amount")]
        public Nullable<int> StockAmount { get; set; }
        [Display(Name = "Dosage")]
        public string Dosage { get; set; }
        [Display(Name = "Ordered By")]
        public Nullable<int> OrderedBy { get; set; }
    
        public virtual tblUser tblUser { get; set; }
    }
}