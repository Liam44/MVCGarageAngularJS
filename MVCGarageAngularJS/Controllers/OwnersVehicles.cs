using MVCGarageAngularJS.Models;
using MVCGarageAngularJS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCGarageAngularJS.Controllers
{
    public class OwnersVehicles
    {
        OwnersRepository owners = new OwnersRepository();
        VehiclesRepository vehicles = new VehiclesRepository();

        //public Owner GetOwnerByVehicle(int vID)
        //{
        //    return owners.GetOwnerByVehicleID(vID);
        //}
    }
}