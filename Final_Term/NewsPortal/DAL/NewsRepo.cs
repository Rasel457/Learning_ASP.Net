using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NewsRepo
    {
        static News_PortalEntities db;
        static NewsRepo()
        {
            db = new News_PortalEntities();
        }
        public static List<News> Get()
        {
            return db.News.ToList();
        }
        public static News ByCatagory(string C_name)
        {
            var a=db.Catagories.First(e => e.Catagory_name == C_name);
           /* var d = (from c in db.News
                        select c.Catagory_id == a.Id).ToList();*/
            //return d;
            return db.News.First(e => e.Catagory_id == a.Id);
            


        }

        public static News ByDate(DateTime d)
        {
            //string date = d.ToString("dd/M/yyyy");

            return db.News.First(e => e.Publish_date == d);
        }
        public static News ByCatagoryAndDate(string catagory,DateTime d)
        {
            var a = db.Catagories.FirstOrDefault(e => e.Catagory_name == catagory);
            return db.News.First(e => e.Catagory_id == a.Id && e.Publish_date==d);
           
        }
        public static void Add(News n)
        {
            db.News.Add(n);
            db.SaveChanges();
        }
        public static void Edit(News n)
        {
            var ds = db.News.FirstOrDefault(e => e.Id == n.Id);
            db.Entry(ds).CurrentValues.SetValues(n);
            db.SaveChanges();
        }
        public static void Delete(int id)
        {
            var st = db.News.FirstOrDefault(e => e.Id == id);
            db.News.Remove(st);
            db.SaveChanges();
        }
    }
}
