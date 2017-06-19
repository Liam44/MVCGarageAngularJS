using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCGarage.Models
{
    public class DefaultFee
    {
        // This allows the 1..1 relation to the "VehicleType" table, forcing the related vehicle type to exist
        // before the creation of the default fee
        [Key, ForeignKey("VehicleType")]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required]
        public double Fee { get; set; }

        // Navigation property - Allows the 1..1 relation to the "VehicleType" table
        [Display(Name = "Vehicle Type")]
        public virtual VehicleType VehicleType { get; set; }
        // --- //
    }
}