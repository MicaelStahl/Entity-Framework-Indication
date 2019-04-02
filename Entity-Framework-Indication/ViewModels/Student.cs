using Entity_Framework_Indication.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string SecondName { get; set; }
        [Required]
        [MaxLength(2)]
        public int? SchoolYear { get; set; }
        [Required]
        [MaxLength(12)]
        public string PhoneNumber { get; set; }
            
        public List<StudentsCourses> Courses { get; set; }
    }
}
