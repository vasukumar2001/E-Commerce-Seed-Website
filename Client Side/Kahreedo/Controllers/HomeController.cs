using Khareedo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Khareedo.Controllers
{
    public class HomeController : Controller
    {
        KhareedoEntities db = new KhareedoEntities();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.SeedProduct = db.Products.Where(x => x.Category.Name.Equals("Til")).ToList();
            ViewBag.SeedProduct = db.Products.Where(x => x.Category.Name.Equals("Ground Nut")).ToList();
            ViewBag.product=db.Products.ToList();
           
            ViewBag.Categories = db.Categories.Select(x => x.Name).ToList();

            this.GetDefaultData();

            return View();
        }      
        public ActionResult Categorylist()
        {
            ViewBag.Categories = db.Categories.Select(x => x.Name).ToList();

            return View();
        }
    }
}