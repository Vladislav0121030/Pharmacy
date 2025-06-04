using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Models
{
    public class MedicineRequest
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }

        [ForeignKey("MedicinePackage")]
        public int? PackageId { get; set; }

        [Required]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Required]
        public int Quantity { get; set; } = 1;

        [Required]
        public bool IsSubstitute { get; set; } = false;

        public virtual Medicine Medicine { get; set; }
        public virtual MedicinePackage MedicinePackage { get; set; }
    }
}