using IntroWebAPI.Models;
using IntroWebAPI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using System.Web.Http.Cors;

namespace IntroWebAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class StudentController : ApiController
    {
        [Route("api/Student/names")]
        [HttpGet]
        public List<string> StNames()
        {
            UMS_AEntities db = new UMS_AEntities();
            var data = (from s in db.Students
                        select s.Name).ToList();
            return data;
        }
        public List<StudentModel> Get()
        {
            UMS_AEntities db = new UMS_AEntities();
            var config = new MapperConfiguration(c =>
                {
                    c.CreateMap<Student, StudentModel>();
                    c.CreateMap<Department, DepartmentModel>();
                }
            );
            var mapper = new Mapper(config);
            var data= mapper.Map<List<StudentModel>>(db.Students.ToList());
            //var data = new List<StudentModel>();
            //foreach (var s in db.Students)
            //{
            //    StudentModel st = new StudentModel()
            //    {
            //        Id = s.Id,
            //        Name = s.Name,
            //        Dob = s.Dob,
            //        Gender = s.Gender,
            //        Cgpa = s.Cgpa,
            //        DepartmentId = s.DepartmentId
            //    };
            //    data.Add(st);

            //}
            return data;
        }
        public StudentModel Get(int id)
        {
            UMS_AEntities db = new UMS_AEntities();
            var s = (from st in db.Students
                       where st.Id == id
                       select st).FirstOrDefault();

            StudentModel sr = new StudentModel()
            {
                Id = s.Id,
                Name = s.Name,
                Dob = s.Dob,
                Gender = s.Gender,
                Cgpa = s.Cgpa,
                DepartmentId = s.DepartmentId

            };
            return sr;

        }
        [Route("api/Student/Create")]
        [HttpPost]
        public void Post(Student s)
        {
            var db = new UMS_AEntities();
            db.Students.Add(s);
            db.SaveChanges();
        }
    }
}
