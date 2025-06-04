using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Models
{
    public class MedicineSubstitute
    {
        [Key]
        public int SubstituteId { get; set; }

        [Required]
        [ForeignKey("OriginalMedicine")]
        public int OriginalMedicineId { get; set; }

        [Required]
        [ForeignKey("SubstituteMedicine")]
        public int SubstituteMedicineId { get; set; }

        public virtual Medicine OriginalMedicine { get; set; }
        public virtual Medicine SubstituteMedicine { get; set; }
    }
}