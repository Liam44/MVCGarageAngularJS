using MVCGarageAngularJS.Models;

namespace MVCGarageAngularJS.Controllers
{
    public class InnerJoinResult
    {
        public ParkingSpot ParkingSpot { get; set; }
        public CheckIn CheckIn { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}