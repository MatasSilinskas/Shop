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
        [HttpPost]
        public ActionResult Search(Discounts discounts)
        {
            string Shop = Request["Search"];
            var discount = db.discounts.Where(x => x.Shop.ShopName == Shop).ToList();
            return View("ViewDiscount", discount);
        }
        [HttpPost]
        public ActionResult SearchToday(Discounts discounts)
        {
            string Shop = Request["SearchToday"];
            var discount = db.discounts.Where(x => x.Shop.ShopName == Shop).Where(x => x.Date >= DateTime.Today).ToList();
            return View("ViewDiscountToday", discount);
        }
        [HttpPost, ActionName("Report")]
        public ActionResult Report(int? id)
        {
            var query =
                    from discount in db.discounts
                    where discount.ItemId == id
                    select discount;
            foreach (Discounts discount in query)
            {
                discount.TimesReported++;
               
            }
            db.SaveChanges();
            return RedirectToAction("ViewDiscount", db.discounts.ToList());
        }
        [HttpPost, ActionName("ReportToday")]
        public ActionResult ReportToday(int? id)
        {
            var query =
                    from discount in db.discounts
                    where discount.ItemId == id
                    select discount;
            foreach (Discounts discount in query)
            {
                discount.TimesReported++;

            }
            db.SaveChanges();
            return RedirectToAction("ViewDiscount", db.discounts.Where(x=>x.Date >= DateTime.Today).ToList());
        }

        protected override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            //lets say you set session value to a positive integer
            var LoginType = Convert.ToInt32(filterContext.HttpContext.Session["UserID"]);
            if (LoginType == 0)
            {
                filterContext.HttpContext.Response.Redirect(url: "~/");
            }

            base.OnAuthorization(filterContext);
        }
    }
}