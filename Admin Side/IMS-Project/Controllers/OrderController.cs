using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMS_Project.Models;

namespace IMS_Project.Controllers
{
    public class OrderController : Controller
    {
        KahreedoEntities db = new KahreedoEntities();
        // GET: Order
        public ActionResult Index()
        {
            return View(db.Orders.OrderByDescending(x => x.OrderID).ToList());
        }
        public void GetViewBagData()
        {
            ViewBag.Status = new SelectList(db.Status, "StatusId", "Status");
          

        }
        public ActionResult invoice(int id)
        {
            Order ord = db.Orders.Find(id);
            var Ord_details = db.OrderDetails.Where(x => x.OrderID == id).ToList();
            var tuple = new Tuple<Order, IEnumerable<OrderDetail>>(ord, Ord_details);

            double SumAmount = Convert.ToDouble(Ord_details.Sum(x => x.TotalAmount));
            ViewBag.TotalItems = Ord_details.Sum(x => x.Quantity);
            ViewBag.Discount = 0;
            ViewBag.TAmount = SumAmount - 0;
            ViewBag.Amount = SumAmount;
            return View(tuple);

        }
        public ActionResult Details(int id)
        {
            Order ord = db.Orders.Find(id);
            var Ord_details = db.OrderDetails.Where(x => x.OrderID == id).ToList();
            var tuple = new Tuple<Order, IEnumerable<OrderDetail>>(ord, Ord_details);

            double SumAmount = Convert.ToDouble(Ord_details.Sum(x => x.TotalAmount));
            ViewBag.TotalItems = Ord_details.Sum(x => x.Quantity);
            ViewBag.Discount = 0;
            ViewBag.TAmount = SumAmount - 0;
            ViewBag.Amount = SumAmount;
            return View(tuple);
        }
        [HttpGet]
        public ActionResult OrderStatusManage()
        {
            var data = db.Orders.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult ChangeStatus(int id)
        {
            Order order= db.Orders.Single(x => x.OrderID == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> items = new List<SelectListItem>();
            
            items.Add(new SelectListItem { Text="Ordered", Value="1" });
            items.Add(new SelectListItem { Text="Shipped", Value="2" });
            items.Add(new SelectListItem { Text="Out For Delivery", Value="3" });
            items.Add(new SelectListItem { Text="Delivered", Value="4" });

            ViewBag.status=items;
            
      

            return View("ChangeStatus", order);
            /* List<SelectListItem> items = new List<SelectListItem>();
             items.Add(new SelectListItem { Text="Pending", Value="1" });
             items.Add(new SelectListItem { Text="In Progress", Value="2" });
             items.Add(new SelectListItem { Text="Shipped", Value="3" });
             items.Add(new SelectListItem { Text="Out of Delivery", Value="4" });
             items.Add(new SelectListItem { Text="Delivered", Value="5" });

             ViewBag.status=items;
 */
            // ViewBag.status =new SelectList(getstatus, "StatusId", "Status"); 
          /*  var raw = db.Orders.Where(model => model.OrderID == id).FirstOrDefault();
            return View(raw);*/
        }

        [HttpPost]
        public ActionResult ChangeStatus(Order o)
        {
            /* // o.Status=ViewBag.status;
              //o.StatusId=ViewBag.status;
              db.Entry(o).State = EntityState.Modified;
              db.SaveChanges();

              return View();*/
            if (ModelState.IsValid)
            {
                db.Entry(o).State = EntityState.Modified;
                db.SaveChanges();
                

                return RedirectToAction("OrderStatusManage", "Order");
            }

            return View(o);
        }
    }
}