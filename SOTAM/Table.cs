using System;
using System.ComponentModel.DataAnnotations;

namespace SOTAM
{
    public class Table
    {
        [Key]  
        public int TableID { get; set; }

        [Required]  
        [MaxLength(50)]
        public string TableName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        public string Customer { get; set; }  

        [Range(0, 13)]  
        public int Hours { get; set; }

        public DateTime? TimeEnd { get; set; }  

        [MaxLength(20)]
        public string TimeLeft { get; set; }  
    }
}
