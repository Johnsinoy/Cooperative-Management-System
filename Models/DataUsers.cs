using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperative_Financing.Models
{
    public class DataUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Id { get; set; }

        [Required]
        public int Member_Id { get; set; }  // ✅ Ensure correct Foreign Key

        [ForeignKey("Member_Id")]
        public virtual Members Member { get; set; }

        [Required]
        public string Password { get; set; }

        public bool Is_Admin { get; set; }

    }
}
