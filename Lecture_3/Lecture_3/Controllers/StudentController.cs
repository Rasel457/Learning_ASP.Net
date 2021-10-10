using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lecture_3.Models.Entity;
using Lecture_3.Models;
using Lecture_3.Auth;

namespace Lecture_3.Controllers
{
    //[Authorize]
    [AdminAccess]
    public class StudentController : Controller
    {
        // GET: Student
       //[Authorize]

        [AllowAnonymous]
        public ActionResult Index()
        {
            /*string connString = @"Server=RASEL\SQLEXPRESS;Database=UMS_A;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            string query = "select * from Students";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Student> students = new List<Student>();
            while(reader.Read())
            {
                Student s = new Student()
                {
                    Id= reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Dob = reader.GetString(reader.GetOrdinal("Dob")),
                    Gender = reader.GetString(reader.GetOrdinal("Gender")),
                    Cgpa = (float) reader.GetDouble(reader.GetOrdinal("Cgpa"))

                };
                students.Add(s);
                
            }
            conn.Close();*/
            Database db = new Database();
            var students = db.Students.GetAll();
            return View(students);
        }
        [HttpGet]
        //[Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            //string connString = @"Server=RASEL\SQLEXPRESS;Database=UMS_A;User Id=sa;Password=ras7498el";
            //string connString = @"Server=RASEL\SQLEXPRESS;Database=UMS_A;Integrated Security=true";
            //SqlConnection conn = new SqlConnection(connString);
            //string query = String.Format("insert into Students values('{0}','{1}','{2}',0.0)", s.Name, s.Dob, s.Gender);
            //SqlCommand cmd = new SqlCommand(query,conn);
            //conn.Open();
            //int r = cmd.ExecuteNonQuery();
            //conn.Close();
            if(ModelState.IsValid)
            {
                Database db = new Database();
                db.Students.Add(s);
                return RedirectToAction("Index");

            }
            return View();
           
        }
    }
}