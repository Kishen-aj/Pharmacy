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
    
    public partial class tblPatient
    {
        [Display(Name = "Patient ID")]
        public int PatientID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "e-Mail Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Cell Number")]
        public string CellNumber { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Chronic Medication")]
        public Nullable<int> ChronicMedication { get; set; }
        [Display(Name = "Repeat Script?")]
        public string RepeatScript { get; set; }
        [Display(Name = "Delivery Required?")]
        public string DeliveryRequired { get; set; }
        [Display(Name = "Hospital")]
        public string Hospital { get; set; }
    
        public virtual tblChronicMedication tblChronicMedication { get; set; }
    }
}
