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

        public static void GetNewsByDate(DateTime d)
        {
            NewsRepo.ByDate(d);
        }

        public static void GetNewsByDateAndCatagory(string cata,DateTime d)
        {
            NewsRepo.ByCatagoryAndDate(cata, d);

        }
    }
}
