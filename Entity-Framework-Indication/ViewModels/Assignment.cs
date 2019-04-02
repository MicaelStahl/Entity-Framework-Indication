using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }
        [Required]
        public DateTime DueToDate { get; set; }
        [MaxLength(5)]
        public string Grades { get; set; }
        
        public Course Course { get; set; }
    }
}
