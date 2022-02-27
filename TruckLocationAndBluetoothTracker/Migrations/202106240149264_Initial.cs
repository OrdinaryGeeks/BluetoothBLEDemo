namespace TruckLocationAndBluetoothTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characterizations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GUID = c.String(),
                        Name = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Services", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.ServiceID);
            
            CreateTable(
                "dbo.Descriptors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GUID = c.String(),
                        Name = c.String(),
                        Value = c.String(),
                        Characterization_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Characterizations", t => t.Characterization_ID)
                .Index(t => t.Characterization_ID);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GUID = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        GUID = c.String(),
                        Name = c.String(),
                        DeviceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.Devices", t => t.DeviceID, cascadeDelete: true)
                .Index(t => t.DeviceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "DeviceID", "dbo.Devices");
            DropForeignKey("dbo.Characterizations", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.Descriptors", "Characterization_ID", "dbo.Characterizations");
            DropIndex("dbo.Services", new[] { "DeviceID" });
            DropIndex("dbo.Descriptors", new[] { "Characterization_ID" });
            DropIndex("dbo.Characterizations", new[] { "ServiceID" });
            DropTable("dbo.Services");
            DropTable("dbo.Devices");
            DropTable("dbo.Descriptors");
            DropTable("dbo.Characterizations");
        }
    }
}
