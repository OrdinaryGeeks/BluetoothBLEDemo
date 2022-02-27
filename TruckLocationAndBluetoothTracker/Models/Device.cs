using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckLocationAndBluetoothTracker.Models
{
    public class Device
    {
        public int ID { get; set; }
        public string GUID { get; set; }
        public string Name { get; set; }

        public int BLEBaseID { get; set; }

        public string State { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}