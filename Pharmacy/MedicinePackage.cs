using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Models
{
    public class MedicinePackage
    {
        [Key]
        public int PackageId { get; set; }

        [Required]
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }

        [Required]
        [ForeignKey("PackageForm")]
        public int PackageFormId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; } = 0;

        public virtual Medicine Medicine { get; set; }
        public virtual PackageForm PackageForm { get; set; }
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public virtual ICollection<MedicineRequest> Requests { get; set; } = new List<MedicineRequest>();
    }
}