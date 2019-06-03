using Online_Store__React_ASPX_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Store__React_ASPX_.Controllers
{
    public class DataController : Controller
    {
        public IList<FoodItems> menuItems;
        // GET: Data
        [HttpGet]
        public ActionResult GetMenuList()
        {
            menuItems = new List<FoodItems>();
            using(var db= new AppDbContext())
            {
                foreach(var f in db.FoodItems)
                {

                    menuItems.Add(f); 
                }

            }


            return Json(menuItems, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public string GetUserID()
        {
            {
                int uid = -1;
                if (Session["UserId"] != null)
                    uid = Convert.ToInt32(Session["UserId"].ToString());
                return uid.ToString();
            }
        }

        [HttpPost]
        public ActionResult PlaceOrder(List<FoodItems> items, int ID)
        {
            bool dbSuccess = false;
            try
            {
                using (var db = new AppDbContext())
                {
                    Order o = new Order();
                    o.CustomerID = ID;
                    o.OrderDate = DateTime.Now;

                    db.Orders.Add(o);
                    db.SaveChanges();

                    int orderID = o.ID;
                    decimal grandTotal = 0;
                    foreach (var f in items)
                    {
                        OrderDetail orderDetail = new OrderDetail
                        {
                            OrderID = orderID,
                            FoodItemID = f.ID,
                            Quantity = f.Quantity,
                            TotalPrice = f.Price * f.Quantity,
                        };
                        db.OrderDetails.Add(orderDetail);
                        grandTotal += orderDetail.TotalPrice;
                    }
                    o.TotalPaid = grandTotal;
                    o.Status = 1;
                    o.OrderDate = DateTime.Now;
                    db.SaveChanges();
                    dbSuccess = true;
                }
            }
            catch (Exception ex)
            {
                //log ex
                dbSuccess = false; 
            }
            if (dbSuccess)
                return Json("success: true", JsonRequestBehavior.AllowGet);
            else
                return Json("sucess: false", JsonRequestBehavior.AllowGet); 
        }

    }
}