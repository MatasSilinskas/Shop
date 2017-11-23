using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Interfaces;
using WEB.Models;
using WEB.SettingsLogic;

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
            PurchasedItem purchasedItem = new PurchasedItem();
            purchaseList.listOfProducts = _context.purchasedItem.ToList<PurchasedItem>().Where(x => x.Date >= _date).ToList();
            return View(purchaseList);
        }
        public ActionResult Ratings()
        {
            ListOfRatings ratings = new ListOfRatings();
            ratings.list = new List<Ratings>();
            
            for(int i = 1; i<=5; i++)
            {
                Ratings rateItem = new Ratings();
                rateItem.rating = i.ToString();
                rateItem.isChecked = false;
                ratings.list.Add(rateItem);
            }
            
            return View(ratings);
        }
        [HttpPost]
        public ActionResult Ratings(ListOfRatings listOfRatings)
        {
            int ratingAdded =0;
            string message = "";
            for(int i = 0; i<5; i++)
            {
                if (listOfRatings.list[i].isChecked)
                {
                    ratingAdded = i+1;
                    RatingChosenEvent add = new RatingChosenEvent();
                    RatingSaveHandle counter = new RatingSaveHandle(listOfRatings.shopToRate, ratingAdded, _context);
                    RatingMessageHandle msg = new RatingMessageHandle(listOfRatings.shopToRate, _context);
                    add.RatingAdded += counter.OnRatingAdded;
                    add.RatingAdded += msg.OnRatingAdded;
                    add.Done();
                    message = msg.ReturnMessage();
                }
            }
            if(ratingAdded ==0)
            {
                ViewBag.rezult = "check a box to submit rating";
            }
            else
            ViewBag.rezult = message;
            return View("Ratings");
        }

    }
}