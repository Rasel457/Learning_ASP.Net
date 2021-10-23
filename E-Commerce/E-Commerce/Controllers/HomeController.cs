using E_Commerce.Models.VM;
using E_Commerce.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var products = ProductRepository.GetAll();
            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult AddtoCart(int id)
        {
            var pm = ProductRepository.Get(id);
            List<ProductModel> products;
            if(Session["cart"]==null)
            {
                products = new List<ProductModel>();
            }
            else
            {
                var json =Session["cart"].ToString();
                products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json);
            }
            products.Add(pm);
            var json2 = new JavaScriptSerializer().Serialize(products);
            Session["cart"] = json2;
            return RedirectToAction("Index");


        }
        public ActionResult Cart()
        {
            if (Session["cart"] !=null)
            {
                var json = Session["cart"].ToString();
                var products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json);
                return View(products);
            }
            return RedirectToAction("Index");
            

        }
        public ActionResult Checkout()
        {
            var json = Session["cart"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json);
            var cid = 1; //User.identity.Name
            OrderRepository.PlaceOrder(products, cid);
            Session.Remove("cart");
            return RedirectToAction("Index");


        }
        public ActionResult MyOrders()
        {
            var cid = 1; //User.identity.Name
            var orders=OrderRepository.MyOrders(cid);
            return View(orders);

        }
    }
}