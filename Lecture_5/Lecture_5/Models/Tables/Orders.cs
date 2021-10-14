using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lecture_5.Models.Entity;
using System.Data.SqlClient;

namespace Lecture_5.Models.Tables
{
    public class Orders
    {
        SqlConnection conn;
        public Orders (SqlConnection conn)
        {
            this.conn = conn;
        }
        public void AddOrderToCart(List<Product> products)
        {
            foreach (var p in products)
            {
                string query = String.Format("insert into Orders values('{0}',{1},{2})", p.Name, p.Price, p.Quantity);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}