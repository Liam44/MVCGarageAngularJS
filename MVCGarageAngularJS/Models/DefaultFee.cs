using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCGarageAngularJS.Models
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

        [Display(Name = "Monthly fee")]
        public double MonthlyFee()
        {
            return Math.Round(70 * 30 * 24 * 60 * Fee / 100, 2, MidpointRounding.AwayFromZero);
        }

        public string DisplayFee()
        {
            return string.Format("{0:C}/min.", Fee);
        }

        public string DisplayMonthlyFee()
        {
            return string.Format("{0:C}/month", MonthlyFee());
        }

        // Navigation property - Allows the 1..1 relation to the "VehicleType" table
        [Display(Name = "Vehicle Type")]
        public virtual VehicleType VehicleType { get; set; }
        // --- //
    }
}