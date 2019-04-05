using Entity_Framework_Indication.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.ViewModels
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Title cannot be longer than 25 characters.")]
        public string Title { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Subject cannot be longer than 50 characters.")]
        public string Subject { get; set; }
        [StringLength(3, ErrorMessage = "Grades cannot be longer than 3 characters.")]
        public string Grades { get; set; }

        public Teacher Teacher { get; set; }

        public List<Assignment> Assignments { get; set; }

        public List<StudentsCourses> StudentsCourses { get; set; }
    }
}
