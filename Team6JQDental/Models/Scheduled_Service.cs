using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team6JQDental.Models
{
    public class Scheduled_Service
    {
        public int Scheduled_Service_ID { get; set; }
        public Nullable<int> Appointment_ID { get; set; }
        public Nullable<int> Service_ID { get; set; }
        public Appointment Appointment { get; set; }
        public Service Service { get; set; }
    }
}