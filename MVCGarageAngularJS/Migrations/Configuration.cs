namespace MVCGarageAngularJS.Migrations
{
    using MVCGarageAngularJS.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCGarageAngularJS.DataAccess.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCGarageAngularJS.DataAccess.GarageContext context)
        {
            #region Instantiating

            VehicleType car = new VehicleType { Type = "Car", Fee = 0.20 };
            VehicleType motorcycle = new VehicleType { Type = "Motorcycle", Fee = 0.50 };
            VehicleType truck = new VehicleType { Type = "Truck", Fee = 0.80 };
            VehicleType bus = new VehicleType { Type = "Bus", Fee = 1.00 };

            Owner Mike = new Owner { Fname = "Mike", Lname = "Daughtrey", Gender = "M", LicenseNumber = "ABC-123-DEF" };
            Owner Wilhelm = new Owner { Fname = "Wilhelm", Lname = "Hansson", Gender = "M", LicenseNumber = "ABC-124-DEF" };
            Owner Liam = new Owner { Fname = "Liam", Lname = "Nottoosure", Gender = "M", LicenseNumber = "ABC-125-DEF" };

            ParkingSpot p1 = new ParkingSpot { Label = "301" };
            ParkingSpot p2 = new ParkingSpot { Label = "302" };
            ParkingSpot p3 = new ParkingSpot { Label = "203" };
            ParkingSpot p4 = new ParkingSpot { Label = "204" };
            ParkingSpot p5 = new ParkingSpot { Label = "101" };
            ParkingSpot p6 = new ParkingSpot { Label = "102" };

            Vehicle v1 = new Vehicle { RegistrationPlate = "ABC123" };
            Vehicle v2 = new Vehicle { RegistrationPlate = "ABC124" };
            Vehicle v3 = new Vehicle { RegistrationPlate = "ABC125" };
            Vehicle v4 = new Vehicle { RegistrationPlate = "ABC126" };
            Vehicle v5 = new Vehicle { RegistrationPlate = "ABC127" };
            Vehicle v6 = new Vehicle { RegistrationPlate = "ABC128" };
            Vehicle v7 = new Vehicle { RegistrationPlate = "ABC129" };

            #endregion

            #region Mapping

            v1.VehicleType = car;
            v1.Owner = Mike;
            v2.VehicleType = car;
            v2.Owner = Wilhelm;
            v3.VehicleType = motorcycle;
            v3.Owner = Liam;
            v4.VehicleType = motorcycle;
            v4.Owner = Mike;
            v5.VehicleType = car;
            v5.Owner = Wilhelm;
            v6.VehicleType = truck;
            v6.Owner = Liam;
            v7.VehicleType = bus;
            v7.Owner = Mike;

            #endregion

            #region Adding to the database

            context.Vehicles.Add(v1);
            context.Vehicles.Add(v2);
            context.Vehicles.Add(v3);
            context.Vehicles.Add(v4);
            context.Vehicles.Add(v5);
            context.Vehicles.Add(v6);
            context.Vehicles.Add(v7);

            context.ParkingSpots.Add(p1);
            context.ParkingSpots.Add(p2);
            context.ParkingSpots.Add(p3);
            context.ParkingSpots.Add(p4);
            context.ParkingSpots.Add(p5);
            context.ParkingSpots.Add(p6);

            context.SaveChanges();

            #endregion
        }
    }
}
