using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Lecture_5.Models.Entity
{
    public class Product
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage="Product name can't be empty")]
        [MinLength(2,ErrorMessage ="Product length at least 2 charecter")]
        [MaxLength(30,ErrorMessage ="Product length ")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Price can't be empty")]
        public int Price { get; set; }
        [Required(ErrorMessage ="Quantity can't be empty")]
        public int Quantity { get; set; }
        [Required(ErrorMessage ="Description can't be empty")]
        public string Description { get; set; }
    }
}