namespace MVCGarageAngularJS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckIns",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CheckInTime = c.DateTime(nullable: false),
                        Booked = c.Boolean(nullable: false),
                        CheckOutTime = c.DateTime(),
                        TotalAmount = c.Double(),
                        ParkingSpotID = c.Int(nullable: false),
                        VehicleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ParkingSpots", t => t.ParkingSpotID, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.ParkingSpotID)
                .Index(t => t.VehicleID);
            
            CreateTable(
                "dbo.ParkingSpots",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Fee = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Int(nullable: false),
                        RegistrationPlate = c.String(),
                        VehicleTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Owners", t => t.OwnerID, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeID, cascadeDelete: true)
                .Index(t => t.OwnerID)
                .Index(t => t.VehicleTypeID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fname = c.String(nullable: false),
                        Lname = c.String(nullable: false),
                        Gender = c.String(maxLength: 1),
                        LicenseNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        DefaultFeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DefaultFees",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Fee = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VehicleTypes", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckIns", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehicleTypeID", "dbo.VehicleTypes");
            DropForeignKey("dbo.DefaultFees", "ID", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "OwnerID", "dbo.Owners");
            DropForeignKey("dbo.CheckIns", "ParkingSpotID", "dbo.ParkingSpots");
            DropIndex("dbo.DefaultFees", new[] { "ID" });
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeID" });
            DropIndex("dbo.Vehicles", new[] { "OwnerID" });
            DropIndex("dbo.CheckIns", new[] { "VehicleID" });
            DropIndex("dbo.CheckIns", new[] { "ParkingSpotID" });
            DropTable("dbo.DefaultFees");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Owners");
            DropTable("dbo.Vehicles");
            DropTable("dbo.ParkingSpots");
            DropTable("dbo.CheckIns");
        }
    }
}
