using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lecture_5.Models.Entity;
using System.Data.SqlClient;

namespace Lecture_5.Models.Tables
{
    public class Products
    {
        SqlConnection conn;
        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Add(Product p)
        {
            string query = String.Format("insert into Products values('{0}',{1},{2},'{3}')", p.Name, p.Price, p.Quantity,p.Description);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public Product Get(int Id)
        {
            return null;
        }
        public List<Product> GetAll()
        {
            string query = "select * from Products";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Price = reader.GetInt32(reader.GetOrdinal("Price")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))

                };
                products.Add(p);

            }
            conn.Close();
            return products;
        }

        public Product Edit(int Id)
        {
            return null;
        }
        public Product Update()
        {
            return null;
        }
        public Product Delete(int Id)
        {
            return null;
        }
    }
}