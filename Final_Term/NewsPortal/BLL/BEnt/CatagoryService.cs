using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace BLL.BEnt
{
    public class CatagoryService
    {
        public static List<CatagoryModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
               
                c.CreateMap<Catagory, CatagoryModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CatagoryModel>>(CatagoryRepo.Get());
            return data;
        }
        public static void Add(CatagoryModel C)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CatagoryModel, Catagory>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Catagory>(C);
            CatagoryRepo.Add(data);
        }
        public static void Edit(CatagoryModel C)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CatagoryModel, Catagory>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Catagory>(C);
            CatagoryRepo.Edit(data);

        }

        public static void Delete(int id)
        {
            CatagoryRepo.Delete(id);
        }
    }
}
