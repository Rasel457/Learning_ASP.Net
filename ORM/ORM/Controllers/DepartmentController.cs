using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORM.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            using(UMS_AEntities db=new UMS_AEntities())
            {
                var departments = db.Departments.ToList();
                return View(departments);
            }
            
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department d)
        {
            using (UMS_AEntities db = new UMS_AEntities())
            {
                db.Departments.Add(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int Id)
        {
            UMS_AEntities db = new UMS_AEntities();
            var dept = (from d in db.Departments
                           where d.Id == Id
                           select d).First();
            return View(dept);

        }
        [HttpPost]
        public ActionResult Edit(Department d)
        {
            using (UMS_AEntities db = new UMS_AEntities())
            {
                var dept = (from dm in db.Departments
                              where dm.Id == d.Id
                              select dm).FirstOrDefault();
                //dept.Name = d.Name;
           
                db.Entry(dept).CurrentValues.SetValues(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Details(int Id)
        {
            UMS_AEntities db = new UMS_AEntities();
            var department = (from d in db.Departments
                           where d.Id == Id
                           select d).First();
            return View(department);
        }

        public ActionResult Delete(int Id)
        {
            using (UMS_AEntities db = new UMS_AEntities())
            {
                Department dept = (from d in db.Departments
                             where d.Id == Id
                             select d).FirstOrDefault();
                return View(dept);
            }

        }
        [HttpPost]
        public ActionResult Delete(Department d)
        {
            using (UMS_AEntities db = new UMS_AEntities())
            {
                var entity = (from dept in db.Departments
                              where dept.Id == d.Id
                              select dept).FirstOrDefault();
                db.Departments.Remove(entity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }

    }
}