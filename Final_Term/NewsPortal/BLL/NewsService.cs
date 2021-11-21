using BLL.BEnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace BLL
{
    public class NewsService
    {
        public static List<NewsModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News, NewsModel>();
                c.CreateMap<Catagory, CatagoryModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(NewsRepo.Get());
            return data;
        }
        /* public static List<string> GetNames()
         {
             //var sl = StudentRepo.Get();
             //var data = (from s in sl
             //            select s.Name).ToList();

             var data = NewsRepo.Get().Select(e => e.Name).ToList();
             return data;
         }*/
        public static void Add(NewsModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsModel, News>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News>(n);
            NewsRepo.Add(data);
        }
        public static void Edit(NewsModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsModel, News>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News>(n);
            NewsRepo.Edit(data);

        }

        public static void Delete(int id)
        {
            NewsRepo.Delete(id);
        }

        public static List<NewsModel> GetNewsByCatagory(string catagory)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News, NewsModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(NewsRepo.ByCatagory(catagory));
            return data;
            // return NewsRepo.ByCatagory(catagory);

        }

        public static List<NewsModel> GetNewsByDate(DateTime d)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News, NewsModel>();
            });
            var mapper = new Mapper(config);
            var da = mapper.Map<List<NewsModel>>(NewsRepo.ByDate(d));
            return da;

        }

        public static List<NewsModel> GetNewsByDateAndCatagory(string cata, DateTime d)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News, NewsModel>();
            });
            var mapper = new Mapper(config);
            var da = mapper.Map<List<NewsModel>>(NewsRepo.ByCatagoryAndDate(cata, d));
            return da;
            //NewsRepo.ByCatagoryAndDate(cata, d);

        }

        public static void AddComment(CommentModel c)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentModel, Comment>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Comment>(c);
            NewsRepo.AddComment(data);
        }

        public static void AddReact(ReactModel r)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReactModel, React>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<React>(r);
            NewsRepo.AddReact(data);
        }

        public static List<NewsWithInfoModel> getAllNews()
        {
            var news = NewsRepo.Get();
            List<NewsWithInfoModel> newsList = new List<NewsWithInfoModel>();
            foreach (var n in news)
            {
                NewsWithInfoModel na = new NewsWithInfoModel();
                na.Id = n.Id;
                na.Title = n.Title;
                na.Body = n.Body;
                na.Publish_date = n.Publish_date;
                na.Author_id= n.Author_id;
                na.Catagory_id= n.Catagory_id;
                List<string> cmt = new List<string>();
                foreach (var c in n.Comments)
                {
                    cmt.Add(c.Comment1);
                }
                na.comments = cmt;

                List<string> rct = new List<string>();
                foreach (var r in n.Reacts)
                {
                    rct.Add(r.Reacts);
                }
                na.reacts = rct;
                newsList.Add(na);
            }
            return newsList;
        }
    }
}
