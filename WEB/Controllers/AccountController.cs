﻿ using System;
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
                if (_context.userAccount.Any(x => x.Username == user.Username))
                {
                    ModelState.AddModelError("Username", "This Username already exists. Try entering a new one");
                    return View(user);
                }
                if (_context.userAccount.Any(x => x.Email == user.Email))
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
              
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Bad Login Credentials");
                return View();
            }
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

        public ActionResult Delete()
        {
            int id = Convert.ToInt32(Session["UserID"]);
            _context.Database.ExecuteSqlCommand("DELETE FROM dbo.UserAccounts WHERE UserID=" + id);
            _context.Database.ExecuteSqlCommand("DELETE FROM dbo.PurchasedItems WHERE UserId=" + id);
            _context.Database.ExecuteSqlCommand("DELETE FROM dbo.Receipts WHERE UserId=" + id);
            return RedirectToAction("Logout");

        }
    }
}