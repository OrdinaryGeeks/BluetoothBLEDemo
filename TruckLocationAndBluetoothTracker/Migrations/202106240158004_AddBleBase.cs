namespace TruckLocationAndBluetoothTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBleBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BLEBases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UID = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Devices", "BLEBaseID", c => c.Int(nullable: false));
            CreateIndex("dbo.Devices", "BLEBaseID");
            AddForeignKey("dbo.Devices", "BLEBaseID", "dbo.BLEBases", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "BLEBaseID", "dbo.BLEBases");
            DropIndex("dbo.Devices", new[] { "BLEBaseID" });
            DropColumn("dbo.Devices", "BLEBaseID");
            DropTable("dbo.BLEBases");
        }
    }
}
