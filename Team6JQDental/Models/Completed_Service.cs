using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team6JQDental.Models
{
    public class Completed_Service
    {
        public int Completed_Service_ID { get; set; }
        public Nullable<int> Service_ID { get; set; }
        public Nullable<int> Visit_ID { get; set; }
        public Service Service { get; set; }
        public Visit Visit { get; set; }
    }
}