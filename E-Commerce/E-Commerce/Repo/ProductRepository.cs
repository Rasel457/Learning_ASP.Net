using E_Commerce.Models.EF;
using E_Commerce.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Repo
{
    public class ProductRepository
    {
        static Entities db;
        static ProductRepository()
        {
            db = new Entities();
        }
        public static ProductModel Get(int id)
        {
            var pro = (from pd in db.Products
                       where pd.Id == id
                       select pd).FirstOrDefault();
            //return new ProductModel()
            //{
            //    Id = pro.Id,
            //    Name = pro.Name,
            //    Price = pro.Price

            //};
            ProductModel pm= new ProductModel()
            {
                Id = pro.Id,
                Name = pro.Name,
                Price = pro.Price

            };
            return pm;
        }

        public static List<ProductModel> GetAll()
        {
            var products = new List<ProductModel>();
            foreach (var pro in db.Products)
            {
                ProductModel pm = new ProductModel()
                {
                    Id = pro.Id,
                    Name = pro.Name,
                    Price = pro.Price

                };
                products.Add(pm);

            }
            return products;
        
        }

    }
}