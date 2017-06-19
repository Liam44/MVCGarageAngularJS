namespace MVCGarageAngularJS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ParkingSpots", "Fee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkingSpots", "Fee", c => c.Double());
        }
    }
}
