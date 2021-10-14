using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lecture_5.Models.Tables;
using System.Data.SqlClient;
namespace Lecture_5.Models
{
    public class Database
    {
        public Products Products { get; set; }
        public Orders Orders { get; set; }
        public Customers Customers { get; set; }
        public Database()
        {
            string connString = @"Server=RASEL\SQLEXPRESS;Database=product;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            Products = new Products(conn);
            Orders = new Orders(conn);
            Customers = new Customers(conn);

        }
    }
}