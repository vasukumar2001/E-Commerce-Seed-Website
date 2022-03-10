using IMS_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_Project.Controllers
{
    public class ProductController : Controller
    {
        KahreedoEntities db = new KahreedoEntities();
        [HttpGet]

        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        [HttpGet]

        public ActionResult Create()
        {
            GetViewBagData();
            return View();
        }
        public void GetViewBagData()
        {
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.SubCategoryID = new SelectList(db.SubCategories, "SubCategoryID", "Name");

        }

        [HttpPost]
        
        public ActionResult Create(HttpPostedFileBase file, Product prod)
        {
            if (ModelState.IsValid)
            {
                string a = @"C:\Users\vasuf\Downloads\E-Commerce\Client Side\Kahreedo";
                string filename = Path.GetFileName(file.FileName);
                string _filename = DateTime.Now.ToString("yymmssfff")+filename;
                string path = Path.Combine(a, "Content", "uploads", _filename);
                prod.Picture1=_filename;

                //foreach (var file in Picture1)
                //{
                //    if (file != null || file.ContentLength > 0)
                //    {
                //        string ext = System.IO.Path.GetExtension(file.FileName);
                //        if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                //        {
                //            file.SaveAs(Path.Combine(Server.MapPath("/Content/Images/large"), Guid.NewGuid() + Path.GetExtension(file.FileName)));

                //            var medImg= Images.ResizeImage(Image.FromFile(file.FileName), 250, 300);
                //            medImg.Save(Path.Combine(Server.MapPath("/Content/Images/medium"), Guid.NewGuid() + Path.GetExtension(file.FileName)));


                //            var smImg = Images.ResizeImage(Image.FromFile(file.FileName), 45, 55);
                //            smImg.Save(Path.Combine(Server.MapPath("/Content/Images/small"), Guid.NewGuid() + Path.GetExtension(file.FileName)));

                //        }
                //    }
                //    db.Products.Add(prod);
                //    db.SaveChanges();
                //    return RedirectToAction("Index", "Product");
                //}
                db.Products.Add(prod);
                file.SaveAs(path);
                db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            GetViewBagData();
            return View();
        }

        //Get Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Single(x => x.ProductID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            GetViewBagData();
            return View("Edit", product);
        }

        //Post Edit
        [HttpPost]
        public ActionResult Edit(Product prod)
        {
           
           
            
          if (ModelState.IsValid)
            {
               

                db.Entry(prod).State = EntityState.Modified;

               
                db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            GetViewBagData();
            return View(prod);
        }
        [HttpGet]

        //Get Details
        public ActionResult Details(int id)
        {
            Product  product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpGet]
        
        //Get Delete
        public ActionResult Delete(int id)
        {
            var product = db.Products.Where(model => model.ProductID == id).FirstOrDefault();
            return View(product);

        }

        //Post Delete Confirmed
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            db.Entry(product).State = EntityState.Deleted;
           /* int a = db.SaveChanges();
            if (a > 0)
            {
                return RedirectToAction("Index");
            }*/
            db.SaveChanges();
            return RedirectToAction("Index");
        } 

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        
    }
}