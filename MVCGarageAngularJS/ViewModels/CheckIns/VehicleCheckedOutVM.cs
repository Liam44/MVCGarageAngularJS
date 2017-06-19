using MVCGarageAngularJS.Models;
using System;

namespace MVCGarageAngularJS.ViewModels.CheckIns
{
    public class VehicleCheckedOutVM
    {
        public CheckIn CheckIn { get; set; }
        public int NbMinutes { get; set; }
    }
}