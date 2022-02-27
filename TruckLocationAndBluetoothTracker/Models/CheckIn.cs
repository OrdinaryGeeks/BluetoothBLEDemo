using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckLocationAndBluetoothTracker.Models
{
    public class CheckIn
    {

        public int ID { get; set; }
        public DateTime DateTime { get; set; }

        public ICollection<BLEBase> BLEBases;
     
    }
}