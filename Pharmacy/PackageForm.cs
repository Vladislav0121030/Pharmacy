using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class PackageForm
    {
        [Key]
        public int PackageFormId { get; set; }

        [Required]
        [StringLength(50)]
        public string FormName { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<MedicinePackage> MedicinePackages { get; set; } = new List<MedicinePackage>();
    }
}