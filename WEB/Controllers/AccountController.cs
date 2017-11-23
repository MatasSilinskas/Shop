 using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using WEB.Interfaces;
using WEB.Models;
using WEB.ShopFromAListLogic;
using WEB.Top5Logic;
using WEB.RegisterLogic;

namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        DateTime _date;
        int _userID;
        List<string> list = new List<string>();
        private readonly IUserAccountDbContext _context;

        public AccountController(IUserAccountDbContext context)
        {
            _context = context;
        }

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
                Register validate = new Register(_context, user.Username, user.Email);
                if (validate.UsernameExists)
                {
                    ModelState.AddModelError("Username", "This Username already exists. Try entering a new one");
                    return View(user);
                }
                if (validate.EmailExists)
                {
                    ModelState.AddModelError("Email", "This Email already exists. Try entering a new one");
                    return View(user);
                }

                _context.userAccount.Add(user);
                _context.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = user.FirstName + " " + user.LastName + " with username: " + user.Username + " succesfully registered!";
            }

            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {

            var usr = _context.userAccount.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
            

            if (usr != null)
            {
                Session["UserID"] = usr.UserID.ToString();
                Session["Username"] = usr.Username.ToString();

                /*_context.purchasedItem.RemoveRange(_context.purchasedItem);
                _context.userAccount.RemoveRange(_context.userAccount);

                _context.SaveChanges();
                */
                return RedirectToAction("Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Bad Login Credentials");
                return View();
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
        [HttpPost]
        public ActionResult Dashboard(PurchaseList datemodel, string submitButton)
        {
            _date = datemodel.date;
            string shopName = datemodel.name;
            PurchaseList purchaseList = new PurchaseList();
            PurchasedItem purchasedItem = new PurchasedItem();
            switch (submitButton)
            {
                case "Show My Statement":
                    purchaseList.fullPrice = 0;
                    purchaseList.listOfProducts = _context.purchasedItem.ToList<PurchasedItem>().Where(x => x.Date >= _date && x.UserId == Convert.ToInt32(Session["UserID"])).ToList();
                    foreach(var item in purchaseList.listOfProducts)
                    {
                        purchaseList.fullPrice += item.Price; 
                    }
                    return View(purchaseList);
                case "Filter By Shop":
                    purchaseList.fullPrice = 0;
                    purchaseList.listOfProducts = _context.purchasedItem.ToList<PurchasedItem>().Where(x => x.Date >= _date && x.ShopName == shopName && x.UserId == Convert.ToInt32(Session["UserID"])).ToList();
                    return View(purchaseList);
                default: return View();
            }
        }
        
        
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}