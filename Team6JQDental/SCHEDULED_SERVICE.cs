//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Team6JQDental
{
    using System;
    using System.Collections.Generic;
    
    public partial class SCHEDULED_SERVICE
    {
        public int Scheduled_Service_ID { get; set; }
        public Nullable<int> Appointment_ID { get; set; }
        public Nullable<int> Service_ID { get; set; }
    
        public virtual APPOINTMENT APPOINTMENT { get; set; }
        public virtual SERVICE SERVICE { get; set; }
    }
}
