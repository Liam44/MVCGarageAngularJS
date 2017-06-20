using MVCGarageAngularJS.Models;
using System.Collections.Generic;

namespace MVCGarageAngularJS.ViewModels.ParkingSpots
{
    public class SelectAParkingSpotVM
    {
        public Vehicle SelectedVehicle { get; set; }

        public IEnumerable<ParkingSpot> ParkingSpots { get; set; }
        public bool CheckIn { get; set; }
    }
}