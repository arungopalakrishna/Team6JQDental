using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team6JQDental.Models
{
    public class VisitViewModel
    {
        public int Visit_ID { get; set; }
        public Nullable<int> Dentist_ID { get; set; }
        public Nullable<int> Patient_ID { get; set; }
        public Nullable<System.DateTime> Visit_Date { get; set; }
        public Nullable<System.DateTime> Visit_Time { get; set; }
        public List<Service> ScheduledServiceList { get; set; }
        public Dentist Dentist { get; set; }
        public Patient Patient { get; set; }
    }
}