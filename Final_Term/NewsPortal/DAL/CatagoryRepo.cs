using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CatagoryRepo
    {
        static News_PortalEntities db;
        static CatagoryRepo()
        {
            db = new News_PortalEntities();
        }
        public static List<Catagory> Get()
        {
            return db.Catagories.ToList();
        }
        public static void Add(Catagory c)
        {
            db.Catagories.Add(c);
            db.SaveChanges();
        }
        public static void Edit(Catagory c)
        {
            var ds = db.Catagories.FirstOrDefault(e => e.Id == c.Id);
            db.Entry(ds).CurrentValues.SetValues(c);
            db.SaveChanges();
        }
        public static void Delete(int id)
        {
            var st = db.Catagories.FirstOrDefault(e => e.Id == id);
            db.Catagories.Remove(st);
            db.SaveChanges();
        }
    }
}
