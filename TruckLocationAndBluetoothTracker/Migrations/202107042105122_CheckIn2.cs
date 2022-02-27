namespace TruckLocationAndBluetoothTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckIn2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BLEBases", "CheckInID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BLEBases", "CheckInID");
        }
    }
}
