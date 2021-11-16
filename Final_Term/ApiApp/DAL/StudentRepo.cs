using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentRepo
    {
        static UMS_AEntities db;
        static StudentRepo()
        {
            db = new UMS_AEntities();
        }
        public static List<Student>Get()
        {
            return db.Students.ToList();
        }
        public static Student Get(int id)
        {
            return db.Students.FirstOrDefault(e => e.Id == id);
        }
        public static void Add(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
        }
        public static void Edit(Student s)
        {
            var ds= db.Students.FirstOrDefault(e => e.Id == s.Id);
            db.Entry(ds).CurrentValues.SetValues(s);
            db.SaveChanges();
        }
        public static void Delete(int id)
        {
            var st=db.Students.FirstOrDefault(e => e.Id == id);
            db.Students.Remove(st);
        }
    }
}
