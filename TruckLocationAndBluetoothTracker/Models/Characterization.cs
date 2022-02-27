using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckLocationAndBluetoothTracker.Models
{
    public class Characterization
    {

        public int ID { get; set; }
        public string GUID { get; set; }
        public int Name { get; set; }
        public int Value { get; set; }

        public int ServiceID { get; set; }
        public virtual ICollection<Descriptor> Descriptors { get; set; }
    }
}