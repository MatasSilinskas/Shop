﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;
using WEB.SettingsLogic;

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
                    RatingAdd add = new RatingAdd();
                    SaveRating counter = new SaveRating(listOfRatings.shopToRate, ratingAdded);
                    RatingMessage msg = new RatingMessage(listOfRatings.shopToRate);
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