using Khareedo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;

namespace Khareedo.Controllers
{
    public class OrderDetailController : Controller
    {
        KhareedoEntities db = new KhareedoEntities();

        // GET: OrderDetail
        public ActionResult Index()
        {
 
            return View(db.Orders.Where(x => x.CustomerID == TempShpData.UserID).ToList());
        }
        public ActionResult Details(int id)
        {
            Order ord = db.Orders.Find(id);
            var Ord_details = db.OrderDetails.Where(x => x.OrderID == id).ToList();
            var tuple = new Tuple<Order, IEnumerable<OrderDetail>>(ord, Ord_details);
            double discount = Convert.ToInt32(Ord_details.Sum(x => x.Discount));

            double SumAmount = Convert.ToDouble(Ord_details.Sum(x => x.TotalAmount));
            ViewBag.TotalItems = Ord_details.Sum(x => x.Quantity);
            ViewBag.Discount = discount;
            ViewBag.TAmount = SumAmount - discount;
            ViewBag.Amount = SumAmount;
            return View(tuple);
        }
        public ActionResult invoice(int id)
        {
            Order ord = db.Orders.Find(id);
            var Ord_details = db.OrderDetails.Where(x => x.OrderID == id).ToList();
            var tuple = new Tuple<Order, IEnumerable<OrderDetail>>(ord, Ord_details);
            
            double discount = Convert.ToInt32(Ord_details.Sum(x => x.Discount));
            double SumAmount = Convert.ToDouble(Ord_details.Sum(x => x.TotalAmount));
            ViewBag.TotalItems = Ord_details.Sum(x => x.Quantity);
            ViewBag.Discount = discount;
            ViewBag.TAmount = SumAmount -discount ;
            ViewBag.Amount = SumAmount;
            return View(tuple);

        }

       

        public ActionResult ExportPDF()
        {
            return new ActionAsPdf("invoice")
            {
                FileName =Server.MapPath("~/Content/Invoice.pdf")

            };
           
        }
       
    }
}