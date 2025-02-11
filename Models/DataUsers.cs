using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperative_Financing.Models
{
    [Table("data_users")]  // Maps the model to the data_users table
    public class DataUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Id { get; set; }  // Primary Key, Auto-Increment

        [ForeignKey("Members")]
        public int Member_Id { get; set; }  // Foreign Key to Members Table
        public Members Member { get; set; }  // Navigation Property

        [Required]
        [StringLength(45)]
        public string Password { get; set; }  // User password (should be stored as a hash)

        [Column(TypeName = "TINYINT(1)")]
        public bool Is_Admin { get; set; } = false;  // Admin status (0 = User, 1 = Admin)

    }
}
