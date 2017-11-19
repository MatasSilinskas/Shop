using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.Controllers
{
    public class SettingsController : Controller
    {
        DateTime _date;
        //DateSettings dateSettings = new DateSettings();
        private readonly IUserAccountDbContext _context;

        public SettingsController(IUserAccountDbContext context)
        {
            _context = context;
        }
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AccountSettings()
        {
            int id = Convert.ToInt32(Session["UserID"]);
            var user = _context.userAccount.Where(x => x.UserID == id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult AccountSettings(UserAccount user)
        {
            var userInDb = _context.userAccount.Single(x => x.UserID == user.UserID);
            if (userInDb == null)
            {
                return HttpNotFound();
            }
            else if (ModelState.IsValid)
            {
                TryUpdateModel(userInDb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult TimeAndDate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TimeAndDate(PurchaseList datemodel)
        {
            _date = datemodel.date;
            PurchaseList purchaseList = new PurchaseList();
            using (UserAccountDbContext db = new UserAccountDbContext())
            {
                PurchasedItem purchasedItem = new PurchasedItem();
                purchaseList.listOfProducts = db.purchasedItem.ToList<PurchasedItem>().Where(x => x.Date >= _date).ToList();
                return View(purchaseList);
            }

        }
    }
}