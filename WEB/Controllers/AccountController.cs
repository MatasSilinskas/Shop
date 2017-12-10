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
using WEB.RemindPasswordLogic;
using System.Threading;
using System.Threading.Tasks;
using WEB.Dashboard;


namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        DateTime _date;
        List<string> list = new List<string>();
        private readonly IUserAccountDbContext _context;
        private Lazy<Statement> lazyStatement;

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
                if ((_context.userAccount.Any(x => x.Username == user.Username))||(_context.shop.Any(x => x.Username == user.Username)))
                {
                    ModelState.AddModelError("Username", "This Username already exists. Try entering a new one");
                    return View(user);
                }
                if ((_context.userAccount.Any(x => x.Email == user.Email))||(_context.shop.Any(x => x.Email == user.Email)))
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
        public ActionResult RegisterShop()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterShop(Shop shop)
        {
            if (ModelState.IsValid)
            {
                if ((_context.shop.Any(x => x.Username == shop.Username))||(_context.userAccount.Any(x => x.Username == shop.Username)))
                {
                    ModelState.AddModelError("Username", "This Username already exists. Try entering a new one");
                    return View(shop);
                }
                if ((_context.shop.Any(x => x.Email == shop.Email))||(_context.userAccount.Any(x => x.Email == shop.Email)))
                {
                    ModelState.AddModelError("Email", "This Email already exists. Try entering a new one");
                    return View(shop);
                }

                _context.shop.Add(shop);
                _context.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = shop.ShopName + " with username: " + shop.Username + " succesfully registered!";
            }

            return RedirectToAction("Login");
        }
        public ActionResult RegisterType()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            var userName = user.Username;
            var password = user.Password;
            var usr1 = _context.userAccount.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();

            if (usr1 != null)
            {
                Session["UserID"] = usr1.UserID.ToString();
                Session["Username"] = usr1.Username.ToString();
                return RedirectToAction("Dashboard");
            }
            else
            {
                var usr2 = _context.shop.Where(u => u.Username == userName && u.Password == password).FirstOrDefault();
                if (usr2 != null)
                {
                    Session["ShopID"] = usr2.ShopID.ToString();
                    Session["Username"] = usr2.Username.ToString();

                    return RedirectToAction("ShopDashboard"); 
                }
                ModelState.AddModelError("", "Bad Login Credentials");
                return View();
            }

        }
        public ActionResult ShopDashboard()
        {
            if (Session["ShopID"] != null)
            {
                int userID = Convert.ToInt32(Session["ShopID"]);
                ViewBag.UserId = Convert.ToInt32(Session["ShopID"]);

                ViewBag.Username = Session["Username"]; 

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

            public ActionResult Dashboard()
        {
            if (Session["UserID"] != null)
            {
                int userID = Convert.ToInt32(Session["UserID"]);
                ViewBag.UserId = Convert.ToInt32(Session["UserID"]);

                ViewBag.Username = Session["Username"];;
                var receipts = _context.receipt.Where(u => u.UserId == userID);
                ViewBag.Receipts = receipts;

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
            PurchaseList purchaseList = new PurchaseList();
            PurchasedItem purchasedItem = new PurchasedItem();
            int userID = Convert.ToInt32(Session["UserID"]);
            var receipts = _context.receipt.Where(u => u.UserId == userID);
            ViewBag.Receipts = receipts;
            lazyStatement = new Lazy<Statement>(() => new Statement(_context, datemodel.date, datemodel.name));
            if ((submitButton == "Show My Statement") || (submitButton == "Filter By Shop"))
            {
                Statement statement = lazyStatement.Value;
                purchaseList = statement.ShowStatement(submitButton, Convert.ToInt32(Session["UserID"]));
                return View(purchaseList);
            }
            else return View();
 
        }

        public ActionResult RemindPassword()
        {
            ViewBag.Alert = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemindPassword(ForgotPassword forgotPassword)
        {
            var user = _context.userAccount.Where(x => x.Email == forgotPassword.Email).FirstOrDefault();
            if (user == null)
            {
                ModelState.AddModelError("Email", "User with this email doesn`t exist. Are you sure you typed it correctly?");
                return View(forgotPassword);
            }
            else
            {
                RemindPassword remind = new RemindPassword(_context);
                remind.SendNewPassword(forgotPassword.Email, user.Username);
                if(remind.EmailSent)
                {
                    ViewBag.Alert = "Message was sent sucessfully!";
                }
                else
                {
                    ViewBag.Alert = "Some problems occured during message sending. Operation failed :(";
                }
                return View(forgotPassword);
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}