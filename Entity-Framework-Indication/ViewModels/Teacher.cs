using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.Models
{
    public class Teacher
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
        [MaxLength(12)]
        public string PhoneNumber { get; set; }
        [MaxLength(20)]
        public string TeachingSubject { get; set; }

        public List<Course> Courses { get; set; }
    }
}
