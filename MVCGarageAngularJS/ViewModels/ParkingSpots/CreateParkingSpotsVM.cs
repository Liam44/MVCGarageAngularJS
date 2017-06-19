using MVCGarageAngularJS.Models;
using System.Collections.Generic;

namespace MVCGarageAngularJS.ViewModels.ParkingSpots
{
    public class CreateParkingSpotsVM
    {
        public ParkingSpot ParkingSpot { get; set; }
        public string ErrorMessage { get; set; }
    }
}