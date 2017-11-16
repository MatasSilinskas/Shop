using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;

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
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult StoreList()
        {
            return View();

        }
        [HttpPost]
        public ActionResult StoreList(ShopFromList shop)
        {
            Debug.WriteLine("\n" + shop.item);
            return View();
        }
        public ActionResult Top5()
        {
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