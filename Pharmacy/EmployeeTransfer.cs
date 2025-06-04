using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Models
{
    public class EmployeeTransfer
    {
        [Key]
        public int TransferId { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [StringLength(50)]
        public string PreviousPosition { get; set; }

        [Required]
        [StringLength(50)]
        public string NewPosition { get; set; }

        [Required]
        [StringLength(100)]
        public string TransferReason { get; set; }

        [Required]
        [StringLength(20)]
        public string OrderNumber { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime TransferDate { get; set; } = DateTime.Now;

        public virtual Employee Employee { get; set; }
    }
}