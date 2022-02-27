using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace TruckLocationAndBluetoothTracker.Models
{
    public class DBContext : DbContext
    {

        public DBContext()
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public System.Data.Entity.DbSet<TruckLocationAndBluetoothTracker.Models.Characterization> Characterizations { get; set; }

        public System.Data.Entity.DbSet<TruckLocationAndBluetoothTracker.Models.Descriptor> Descriptors { get; set; }

        public System.Data.Entity.DbSet<TruckLocationAndBluetoothTracker.Models.Device> Devices { get; set; }

        public System.Data.Entity.DbSet<TruckLocationAndBluetoothTracker.Models.Service> Services { get; set; }

        public System.Data.Entity.DbSet<TruckLocationAndBluetoothTracker.Models.BLEBase> BLEBases { get; set; }

        public System.Data.Entity.DbSet<TruckLocationAndBluetoothTracker.Models.CheckIn> CheckIns { get; set; }
    }
}