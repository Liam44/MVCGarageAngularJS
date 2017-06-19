using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCGarageAngularJS.Models
{
    public class VehicleType
    {
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required] 
        public string Type { get; set; }

        // Navigation property - Allows the 1..* relation to the "Vehicle" table
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        // --- //

        // Navigation property - Allows the 1..1 relation to the "DefaultFee" table
        [Display(Name = "Default Fee")]
        public virtual DefaultFee DefaultFee { get; set; }
        // --- //
    }
}