using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.ViewModels
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Title cannot be longer than 25 characters.")]
        public string Title { get; set; }
        [StringLength(250, ErrorMessage = "Description cannot be longer than 250 characters.")]
        public string Description { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Subject cannot be longer than 50 characters.")]
        public string Subject { get; set; }
        [Required]
        public DateTime DueToDate { get; set; }
        [StringLength(3, ErrorMessage = "Grades cannot be longer than 3 characters.")]
        public string Grades { get; set; }
        
        public Course Course { get; set; }
    }
}
