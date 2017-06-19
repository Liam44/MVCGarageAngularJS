using MVCGarageAngularJS.Models;
using System.Collections.Generic;

namespace MVCGarageAngularJS.ViewModels.CheckIns
{
    public class ParkingSpotHistoricVM
    {
        public ParkingSpot ParkingSpot { get; set; }
        public IEnumerable<CheckIn> CheckIns { get; set; }
    }
}