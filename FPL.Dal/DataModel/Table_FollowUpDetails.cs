//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FPL.Dal.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Table_FollowUpDetails
    {
        public int ID { get; set; }
        public Nullable<int> InvoiceID { get; set; }
        public Nullable<int> MachineNumber { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> ModelID { get; set; }
        public string ModelName { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string ContactPerson { get; set; }
        public string Remarks { get; set; }
        public string OurPerson { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string PaymentsList { get; set; }
    }
}
