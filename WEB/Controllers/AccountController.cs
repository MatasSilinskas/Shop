using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using WEB.Models;
using WEB.ShopFromAListLogic;

namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        List<string> list = new List<string>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                using (UserAccountDbContext db = new UserAccountDbContext())
                {
                    db.userAccount.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.FirstName + " " + user.LastName + " with username: " + user.Username + " succesfully registered!";


            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (UserAccountDbContext db = new UserAccountDbContext())
            {
                var usr = db.userAccount.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                
                if (usr != null)
                {
                    
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    /*db.userAccount.RemoveRange(db.userAccount);
                    db.SaveChanges();*/
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Bad Login Credentials");
                    return View();
                }
            }
        }

        public ActionResult Dashboard()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.UserId = Convert.ToInt32(Session["UserID"]);
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult StoreList()
        {
            PurchaseList purchaseList = new PurchaseList();
            using (UserAccountDbContext db = new UserAccountDbContext())
            {
                purchaseList.listOfProducts = db.purchasedItem.ToList<PurchasedItem>();
            }
            return View(purchaseList);
        }
        
        [HttpPost]
        public ActionResult StoreList(PurchaseList purchaseList)
        {
            if (purchaseList != null)
            {
                var _selectedProducts = purchaseList.listOfProducts.Where(x => x.IsChecked == true).ToList<PurchasedItem>();
                List<string> list = new List<string>();
                foreach (var item in _selectedProducts)
                {
                    list.Add(item.ItemName);
                }
                FromList fromList = new FromList(list, DateTime.Now.AddMonths(-1));
                ViewBag.rezult = fromList.ReturnStoreName();
                return View("StoreList");
            }
            else
            {
                ViewBag.rezult = "Please some check boxes to add items to your list";
                return View("StoreList");
            }
           
        }
        public ActionResult Top5()
        {
            using (UserAccountDbContext db = new UserAccountDbContext())
            {
                /*db.purchasedItem.Add(new PurchasedItem
                {
                    Date = new DateTime(2017, 11, 18),
                    ItemName = "Pienas",
                    Price = 0.99,
                    ShopName = "Maxima",
                    UserId = Convert.ToInt32(Session["UserID"]),
                    IsChecked = false
                });
                db.SaveChanges();*/
            }
            var items = new Top5(Convert.ToInt32(Session["UserID"]));
            ViewBag.Warning = items.Warning;
            ViewBag.Shop = items.Recommendation.Key;
            ViewBag.Price = items.Recommendation.Value; 
            return View(items.Items);
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }      
    }
}