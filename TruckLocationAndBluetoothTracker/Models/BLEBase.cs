using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckLocationAndBluetoothTracker.Models
{
    public class BLEBase
    {
        public int ID { get; set; }

        //Phone Number for phones
        public string UID { get; set; }
        public virtual ICollection<Device> Devices { get; set; }

        public int CheckInID { get; set; }
        public DateTime LogInDate { get; set; }
    }
}