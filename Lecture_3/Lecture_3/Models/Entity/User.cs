using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lecture_3.Models.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage ="Name must be required")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password must be required")]
        public string Password { get; set; }
    }
}