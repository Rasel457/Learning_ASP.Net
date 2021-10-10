using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecture_3.Models.Entity
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Your Name")]
        [MinLength(2,ErrorMessage="Name must be at least 2 charecter")]
        [MaxLength(15,ErrorMessage = "Name should not exceed 15 charecter")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Birth day")]
        public string Dob { get; set; }
        [Required(ErrorMessage = "Please Enter Your Gender")]
        public string Gender { get; set; }
        public float Cgpa { get; set; }
    }
}