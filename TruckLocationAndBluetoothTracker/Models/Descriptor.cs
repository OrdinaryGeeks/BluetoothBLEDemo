using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckLocationAndBluetoothTracker.Models
{
    public class Descriptor
    {

        public int ID { get; set; }
        public string GUID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}