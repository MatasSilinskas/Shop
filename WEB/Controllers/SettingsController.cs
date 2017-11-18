using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class SettingsController : Controller
    {
        DateTime _date;
        //DateSettings dateSettings = new DateSettings();
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AccountSettings()
        {
            return View();
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