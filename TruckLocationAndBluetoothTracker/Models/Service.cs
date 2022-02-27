using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckLocationAndBluetoothTracker.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string GUID { get; set; }
        public string Name { get; set; }

        public int DeviceID { get; set; }
        public virtual ICollection<Characterization> Characterizations{get;set;}
    }
}