using Entity_Framework_Indication.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.ViewModels
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Firstname cannot be longer than 20 letters.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Secondname cannot be longer than 20 letters.")]
        public string SecondName { get; set; }
        [Required]
        [StringLength(6, ErrorMessage = "Schoolyear cannot be longer than 6 characters.")]
        public string SchoolYear { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "Number cannot be longer than 12 characters.")]
        public string PhoneNumber { get; set; }
            
        public List<StudentsCourses> StudentsCourses { get; set; }
    }
}
