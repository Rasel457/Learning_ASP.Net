using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lecture_5.Models.Entity;
using System.Data.SqlClient;

namespace Lecture_5.Models.Tables
{
    public class Customers
    {
        SqlConnection conn;
        public Customers(SqlConnection conn)
        {
            this.conn = conn;
        }
        public Customer Authenticate(string phone, string password)
        {
            Customer customer = null;
            conn.Open();
            string query = string.Format("select * from Customers where Phone='{0}' and Password='{1}'", phone, password);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                customer = new Customer()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Phone = reader.GetString(reader.GetOrdinal("Phone"))
                };
            }
            conn.Close();
            return customer;

        }
        public int GetUserType(string name)
        {
            int type = 0;
            conn.Open();
            string query = string.Format("select * from Customers where Name='{0}'", name);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                type = reader.GetInt32(reader.GetOrdinal("Type"));

            }
            conn.Close();
            return type;

        }
    }
}