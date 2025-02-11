using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperative_Financing.Models
{
    [Table("payments")]
    public class Payments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Payment_Id { get; set; }  // Primary Key, Auto-Increment

        [ForeignKey("Loans")]
        public int Loan_Id { get; set; }  // Foreign Key to Loans Table
        public Loans Loan { get; set; }  // Navigation Property

        [ForeignKey("Members")]
        public int Member_Id { get; set; }  // Foreign Key to Members Table
        public Members Member { get; set; }  // Navigation Property

        [Column(TypeName = "date")]
        [Required]
        public DateTime Payment_Date { get; set; }  // Date of payment

        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal Payment_Amount { get; set; }  // Amount paid

    }
}
