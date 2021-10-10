﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Lecture_3.Models.Entity;

namespace Lecture_3.Models.Tables
{
    public class Users
    {
        SqlConnection conn;
        public Users(SqlConnection conn)
        {
            this.conn = conn;
        }
        public User Authenticate(string username,string password)
        {
            User user = null;
            conn.Open();
            string query = string.Format("select * from Users where Username='{0}' and Password='{1}'", username, password);
            SqlCommand cmd = new SqlCommand(query,conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                user = new User()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Username= reader.GetString(reader.GetOrdinal("Username"))
                };
            }
            conn.Close();
            return user;

        }

        public int GetUserType(string username)
        {
            int type = 0;
            conn.Open();
            string query = string.Format("select * from Users where Username='{0}'", username);
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