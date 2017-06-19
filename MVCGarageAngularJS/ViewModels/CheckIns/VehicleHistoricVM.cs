using MVCGarageAngularJS.Models;
using System.Collections.Generic;

namespace MVCGarageAngularJS.ViewModels.CheckIns
{
    public class VehicleHistoricVM
    {
        public Vehicle Vehicle { get; set; }
        public IEnumerable<CheckIn> CheckIns { get; set; }
    }
}