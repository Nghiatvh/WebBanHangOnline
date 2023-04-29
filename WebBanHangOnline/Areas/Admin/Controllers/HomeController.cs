using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    
    public class HomeController : Controller
    {
        // GET: Admin/Home
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var now = DateTime.Now;
            var revenueMonth = now.AddDays(-30);
            IEnumerable<Order> items = db.Orders.Where(x => x.CreatedDate >= revenueMonth && x.CreatedDate <= now);
            var item = items.ToList();
            var countItem = item.Count();
            var amount = item.Sum(m => m.TotalAmount);
            ViewBag.CountItem = countItem;
            ViewBag.CountAmount = amount;


            return View();
        }
    }
}