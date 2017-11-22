﻿using System;
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
        public ActionResult StoreList()
        {
            PurchaseList purchaseList = new PurchaseList();
            purchaseList.listOfProducts = _context.purchasedItem.ToList<PurchasedItem>();
            return View(purchaseList);
        }

        [HttpPost]
        public ActionResult StoreList(PurchaseList purchaseList)
        {
            try
            {
                var _selectedProducts = purchaseList.listOfProducts.Where(x => x.IsChecked == true).ToList<PurchasedItem>();
                List<string> list = new List<string>();
                foreach (var item in _selectedProducts)
                {
                    if (!list.Contains(item.ItemName))
                    {
                        list.Add(item.ItemName);
                    }

                }
                FromList fromList = new FromList(_context, list, DateTime.Now.AddMonths(-1));
                ViewBag.rezult = fromList.ReturnStoreName();
                return View("StoreList");
            }
            catch (Exception e)
            {
                ViewBag.rezult = "Please some check boxes to add items to your list";
                return View("StoreList");
            }

        }
        public ActionResult Top5()
        {

            /*_context.purchasedItem.Add(new PurchasedItem
            {
                Date = new DateTime(2017, 11, 18),
                ItemName = "Juoda Duona",
                Price = 0.89,
                ShopName = "Iki",
                UserId = Convert.ToInt32(Session["UserID"]),
                IsChecked = false
            });
            _context.SaveChanges();*/

            var items = new Top5(Convert.ToInt32(Session["UserID"]), _context);
            ViewBag.Warning = items.Warning;

            if (items.Recommendation.Key != null)
            {
                ViewBag.Shop = items.Recommendation.Key;
            }
            else
            {
                ViewBag.Shop = "";
            }

            ViewBag.Price = items.Recommendation.Value;
            return View(items.Items);
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