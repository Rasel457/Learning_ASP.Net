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
        public static List<News> ByCatagory(string C_name)
        {
            var a=db.Catagories.First(e => e.Catagory_name == C_name);
           var d = (from c in db.News
                         where c.Catagory_id == a.Id
                    select c).ToList();
            return d;
            //return db.News.First(e => e.Catagory_id == a.Id);
            


        }

        public static List<News> ByDate(DateTime date)
        {
            var data = (from c in db.News
                     where c.Publish_date == date
                     select c).ToList();
            return data;

            //return db.News.First(e => e.Publish_date == d);
        }
        public static List<News> ByCatagoryAndDate(string catagory,DateTime d)
        {
            var a = db.Catagories.FirstOrDefault(e => e.Catagory_name == catagory);
            var data = (from n in db.News
                        where n.Catagory_id == a.Id && n.Publish_date == d
                        select n).ToList();
            return data;
            //return db.News.First(e => e.Catagory_id == a.Id && e.Publish_date==d);
           
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

        public static void AddComment(Comment c)
        {
            db.Comments.Add(c);
            db.SaveChanges();
        }
        public static void AddReact(React r)
        {
            db.Reacts.Add(r);
            db.SaveChanges();
        }
    }
}
