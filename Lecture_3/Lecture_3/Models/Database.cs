﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lecture_3.Models.Tables;
using System.Data.SqlClient;

namespace Lecture_3.Models
{
    public class Database
    {
        public Students Students { get; set; }
        public Courses Courses { get; set; }
        public Faculties Faculties { get; set; }
        public Users Users { get; set; }

        public Database()
        {
            string connString = @"Server=RASEL\SQLEXPRESS;Database=UMS_A;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            Students = new Students(conn);
            Courses = new Courses();
            Faculties = new Faculties();
            Users = new Users(conn);
        }
    }
}