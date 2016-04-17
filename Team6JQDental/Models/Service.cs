using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team6JQDental.Models
{
    public class Service
    {
        public int Service_ID { get; set; }
        public string Service_Description { get; set; }
        public Nullable<decimal> Service_Cost { get; set; }       
    }
}