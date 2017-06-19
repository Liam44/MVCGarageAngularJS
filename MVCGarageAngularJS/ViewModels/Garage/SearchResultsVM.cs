using MVCGarageAngularJS.Models;
using MVCGarageAngularJS.ViewModels.Shared;
using System.Collections.Generic;

namespace MVCGarageAngularJS.ViewModels.Garage
{
    public class SearchResultsVM
    {
        public string SearchedValue { get; set; }
        public DisplayVehiclesVM FoundVehicles { get; set; }
        public IEnumerable<DetailsParkingSpotVM> FoundParkingSpots { get; set; }
    }
}