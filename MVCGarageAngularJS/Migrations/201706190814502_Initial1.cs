namespace MVCGarageAngularJS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VehicleTypes", "DefaultFeeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleTypes", "DefaultFeeID", c => c.Int(nullable: false));
        }
    }
}
