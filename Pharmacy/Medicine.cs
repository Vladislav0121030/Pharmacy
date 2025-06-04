using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [Required]
        [StringLength(100)]
        public string MedicineName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public virtual ICollection<MedicinePackage> Packages { get; set; } = new List<MedicinePackage>();
        public virtual ICollection<MedicineSubstitute> OriginalMedicines { get; set; } = new List<MedicineSubstitute>();
        public virtual ICollection<MedicineSubstitute> SubstituteMedicines { get; set; } = new List<MedicineSubstitute>();
        public virtual ICollection<MedicineRequest> Requests { get; set; } = new List<MedicineRequest>();
    }
}