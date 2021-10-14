using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lecture_5.Models.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string  ProductName { get; set; }
        public int TotalPrice { get; set; }
        public int Quantity { get; set; }

    }
}