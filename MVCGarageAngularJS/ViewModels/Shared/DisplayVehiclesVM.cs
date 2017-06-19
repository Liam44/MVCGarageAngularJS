using MVCGarageAngularJS.Models;
using System.Collections.Generic;

namespace MVCGarageAngularJS.ViewModels.Shared
{
    public class DisplayVehiclesVM
    {
        public string ViewName { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<VehicleType> Types { get; set; }
        public Dictionary<int, CheckIn> ParkingSpotsVehicles { get; set; }
    }
}