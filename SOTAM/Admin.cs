using System.ComponentModel.DataAnnotations;

namespace SOTAM
{
    public class Admin
    {
        [Key]  
        public int AdminID { get; set; }

        [Required]  
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]  
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]  
        [MaxLength(255)]  
        public string Password { get; set; }
    }
}
