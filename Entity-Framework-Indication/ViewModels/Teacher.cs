﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.ViewModels
{
    public class Teacher
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
        [StringLength(50, ErrorMessage = "Specification cannot be longer than 50 letters.")]
        public string Specification { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "Number cannot be longer than 12 characters.")]
        public string PhoneNumber { get; set; }

        public List<Course> Courses { get; set; }
    }
}
