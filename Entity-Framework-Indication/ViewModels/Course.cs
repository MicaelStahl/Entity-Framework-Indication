using Entity_Framework_Indication.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }
        [MaxLength(5)]
        public string Grades { get; set; }

        public Teacher Teacher { get; set; }

        public List<Assignment> Assignments { get; set; }

        public List<StudentsCourses> Students { get; set; }
    }
}
