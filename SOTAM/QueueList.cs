using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SOTAM
{
    public class QueueList
    {
        [Key]  
        public int QueueID { get; set; }

        [Required]  
        [MaxLength(100)]
        public string Customer { get; set; }

        [Range(1, 13)]  
        public int Hours { get; set; }

        [ForeignKey("TableID")]  
        public int? TableID { get; set; }
    }
}
