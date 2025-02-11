using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperative_Financing.Models
{
    public class Payments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Payment_Id { get; set; }

        [Required]
        public int Loan_Id { get; set; }

        [Required]
        public int Member_Id { get; set; }  // ✅ Ensure Foreign Key Property Exists

        // ✅ Explicitly Define Foreign Key Relationships
        [ForeignKey(nameof(Loan_Id))]
        public virtual Loans Loan { get; set; }

        [ForeignKey(nameof(Member_Id))]
        public virtual Members Member { get; set; }

        [Column(TypeName = "date")]
        public DateTime Payment_Date { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Payment_Amount { get; set; }

    }
}
