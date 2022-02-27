namespace TruckLocationAndBluetoothTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Checkin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BLEBases", "LogInDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Devices", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "State");
            DropColumn("dbo.BLEBases", "LogInDate");
        }
    }
}
