using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCGarageAngularJS.Models
{
    public class ParkingSpot
    {
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Identifiant")]
        public string Label { get; set; }

        // Navigation property - Allows the 1..* relation to the "CheckIn" table
        public virtual ICollection<CheckIn> CheckIns { get; set; }
        // --- //
    }
}