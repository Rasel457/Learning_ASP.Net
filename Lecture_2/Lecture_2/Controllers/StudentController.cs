using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lecture_2.Models;

namespace Lecture_2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            Student s1 = new Student()
            {
                Name = "Rasel",
                Id = "18-37990-2",
                Dob = "7 April 1998"

            };
            //ViewBag.Name = "Rasel";
            //string[] names = new string[3];
            //names[0] = "Sabbir";
            //names[1] = "Tanvir";
            //names[2] = "Ahmed";

            //ViewBag.Names = names;

            return View(s1);
        }

        public ActionResult List()
        {
            List<Student> students = new List<Student>();
            {
                for (int i = 0; i < 10; i++)
                {
                    Student s1 = new Student()
                    {
                        Name = "Rasel" +(i+1),
                        Id = "18-37990-2",
                        Dob = "7 April 1998"

                    };
                    students.Add(s1);
                }
                return View(students);
            }
            
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateSubmit(Student s)
        { 
            //Student s = new Student();

            //var c = Request;
            //from HttpRequestBase Request
            //s.Name = Request["Name"];
            //s.Id = Request["Id"];
            //s.Dob = Request["Dob"];
            //return View(s);

            /* s.Name = form["Name"];
             s.Id = form["Id"];
             s.Dob = form["Dob"];*/

            //from direct variable
            //s.Name = Name;
            //s.Id = Id;
            //s.Dob = Dob;
            return View(s);
        }
    }
}