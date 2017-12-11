using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class ViewDiscountController : Controller
    {
        // GET: ViewDiscount
        private UserAccountDbContext db = new UserAccountDbContext();
        
        public ActionResult ViewDiscount()
        {
            var discounts = db.discounts.Include("Shop");
            return View(discounts.ToList());
        }
        public ActionResult ViewDiscountToday()
        {
            var discounts = db.discounts.Include("Shop");
            return View(discounts.Where(x => x.Date >= DateTime.Today).ToList());
        }
    }
}