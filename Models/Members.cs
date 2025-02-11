using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cooperative_Financing.Models
{
    public class Members
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Member_Id { get; set; }  // Primary Key, Auto-Increment

        [Required]
        [StringLength(45)]
        public string First_Name { get; set; }

        [Required]
        [StringLength(45)]
        public string Last_Name { get; set; }

        [StringLength(45)]
        public string Street { get; set; }

        [StringLength(45)]
        public string City { get; set; }

        [StringLength(45)]
        public string Province { get; set; }

        [Required]
        public string Phone { get; set; }  // Using string to support various phone formats

        [Required]
        public string Email { get; set; }  // LongText in MySQL maps to string

        [Column(TypeName = "date")]
        public DateTime JoinDate { get; set; }

        [StringLength(45)]
        public string Contribution { get; set; }
    }
}
