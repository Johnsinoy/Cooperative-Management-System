using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperative_Financing.Models
{
    [Table("loans")]
    public class Loans
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Loan_Id { get; set; }  // Primary Key, Auto-Increment

        [ForeignKey("Members")]
        public int Member_Id { get; set; }  // Foreign Key to Members Table
        public Members Member { get; set; }  // Navigation Property

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Loan_Amount { get; set; }  // Loan amount

        [Required]
        [StringLength(45)]
        public string Purpose_Loan { get; set; }  // Loan purpose

        public float Annual_Interest { get; set; }  // Annual Interest Rate

        public int Term { get; set; }  // Loan term in months

        [Column(TypeName = "date")]
        public DateTime Release_Date { get; set; }  // Loan approval date

        [Column(TypeName = "date")]
        public DateTime First_Month { get; set; }  // Start of repayment

        [Column(TypeName = "date")]
        public DateTime End_Month { get; set; }  // Loan end date

        [Column(TypeName = "decimal(10,2)")]
        public decimal Monthly_Payment { get; set; }  // Monthly repayment amount

        [Column(TypeName = "decimal(10,2)")]
        public decimal Total_Payment { get; set; }  // Total amount to be paid

        [Required]
        [StringLength(10)]
        public string Status { get; set; } = "Pending";  // Default status: Pending

    }
}
