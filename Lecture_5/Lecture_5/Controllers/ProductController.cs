﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lecture_5.Models.Entity;
using Lecture_5.Models;
using System.Web.Script.Serialization;



namespace Lecture_5.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult List()
        {
            Database db = new Database();
            var products = db.Products.GetAll();
            return View(products);

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Add(p);
                return RedirectToAction("List");

            }
            return View();

        }
        [HttpGet]

        public ActionResult Edit(int id)
        {
            Database db = new Database();
            var p = db.Products.Get(id);
            return View(p);

        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Update(p);
                return RedirectToAction("List");

            }
            return View();

        }

        public ActionResult Delete(int id)
        {
            Database db = new Database();
            db.Products.Delete(id);

            return RedirectToAction("List");
        }

        public ActionResult Cart(int id)
        {
            Database db = new Database();
            var p = db.Products.GetItem(id);
            if (p != null)
            {
                List<Product> Products = new List<Product>();
                if (Session["cart"] == null)
                {
                    Products.Add(p);
                    string j_string = new JavaScriptSerializer().Serialize(Products);
                    Session["cart"] = j_string;
                    Session["flag"] = null;
                    return RedirectToAction("List");

                }
                else
                {
                    var j_String = Session["cart"].ToString();
                    var val = new JavaScriptSerializer().Deserialize<List<Product>>(j_String);
                    val.Add(p);
                    Session["cart"] = new JavaScriptSerializer().Serialize(val);
                    return RedirectToAction("List");

                }
                
            }
            return RedirectToAction("List");


        }
        public ActionResult Checkout()
        {
            if (Session["cart"] != null)
            {
                var products = new JavaScriptSerializer().Deserialize<List<Product>>(Session["cart"].ToString());


                return View(products);

            }
            Session["Message"] = "True";
            return Redirect("/product/List");
        }
    }
}