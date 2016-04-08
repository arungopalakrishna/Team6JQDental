using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team6JQDental.Models
{
    public class Appointment
    {
        public int Appointment_ID { get; set; }
        public Nullable<int> Dentist_ID { get; set; }
        public Nullable<int> Patient_ID { get; set; }
        public Nullable<System.DateTime> Appointment_Date { get; set; }
        public Nullable<System.DateTime> Appointment_Time { get; set; }
        public string Scheduled_ServiceID{ get; set; }

        // Assumption for the remainder of the project.
        private int _durationInHours = 1;
        /// <summary>
        /// Duration Hours of an appointment is always 1 hour.
        /// </summary>
        public int DurationinHours
        {
             get
            {
                return _durationInHours;
            }
        }
    }
}