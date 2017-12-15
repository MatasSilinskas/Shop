using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.Controllers
{
    public class DiscountController : Controller
    {
        private UserAccountDbContext db = new UserAccountDbContext();
        private readonly IUserAccountDbContext _context;
        public DiscountController(IUserAccountDbContext context)
        {
            _context = context;
        }
        
        public ActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNew(Discounts discounts)
        {
            try
            {
                string username = Convert.ToString(Session["Username"]);
                var user = _context.shop.Where(u => u.Username == username).FirstOrDefault();
                discounts.Shop = user;
                _context.discounts.Add(discounts);
                _context.SaveChanges();
                ViewBag.rezult = "a new discount was added";
                return View();
            }
            catch
            {
                ViewBag.rezult = "please, try again";
                return View();
            }

        }
        // GET: Discounts
        public ActionResult Manage()
        {
            return View(db.discounts.ToList());
        }
        public ActionResult ManageToday()
        {
            return View(db.discounts.Where(x => x.Date >= DateTime.Today).ToList());
        }
        // GET: Discounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discounts discounts = db.discounts.Find(id);
            if (discounts == null)
            {
                return HttpNotFound();
            }
            return View(discounts);
        }
        // GET: Discounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discounts discounts = db.discounts.Find(id);
            if (discounts == null)
            {
                return HttpNotFound();
            }
            return View(discounts);
        }
        

        // POST: Discounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,ItemName,Discount,PriceBefore,PriceAfter,Date,MoreInfo")] Discounts discounts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discounts);
        }

        // GET: Discounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discounts discounts = db.discounts.Find(id);
            if (discounts == null)
            {
                return HttpNotFound();
            }
            return View(discounts);
        }

        // POST: Discounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Discounts discounts = db.discounts.Find(id);
            db.discounts.Remove(discounts);
            db.SaveChanges();
            return RedirectToAction("Manage");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
