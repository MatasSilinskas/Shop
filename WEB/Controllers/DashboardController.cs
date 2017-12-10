using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Dashboard;
using WEB.Interfaces;
using WEB.Models;
using PagedList;

namespace WEB.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUserAccountDbContext _context;

        public DashboardController(IUserAccountDbContext context)
        {
            _context = context;
        }

        public ActionResult Dashboard()
        {
            ViewBag.SelectedShop = String.Empty;
            AddShopsAndReceipts();
            return View();
        }

        [HttpPost]
        public ActionResult Dashboard(PurchaseList list)
        {
            AddShopsAndReceipts();
            ViewBag.OnePageOfProducts = list.listOfProducts.ToPagedList(1, 10);
            return View("Dashboard", list);
        }

        public ActionResult Pages(int page)
        {
            var list = TempData["List"] as PurchaseList;
            ViewBag.OnePageOfProducts = list.listOfProducts.ToPagedList(page, 10);
            AddShopsAndReceipts();
            ViewBag.SelectedShop = list.name;
            TempData["List"] = list;
            return View("Dashboard", list);
        }

        [HttpPost]
        public ActionResult FilterByDate(PurchaseList datemodel)
        {
            Statement statement = new Statement(_context, datemodel.date, String.Empty, Convert.ToInt32(Session["UserID"]));
            PurchaseList list = statement.FilterByDate();
            ViewBag.SelectedShop = String.Empty;
            TempData["List"] = list;
            return Dashboard(list);
        }

        [HttpPost]
        public ActionResult FilterByShop(PurchaseList datemodel)
        {
            Statement statement = new Statement(_context, datemodel.date, datemodel.name, Convert.ToInt32(Session["UserID"]));
            PurchaseList list = statement.FilterByShop();
            ViewBag.SelectedShop = datemodel.name;
            TempData["List"] = list;
            return Dashboard(list);
        }

        private void AddShopsAndReceipts()
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            ViewBag.Username = _context.userAccount.Where(x => x.UserID == userID).First().FirstName;
            var receipts = _context.receipt.Where(u => u.UserId == userID);
            ViewBag.Receipts = receipts;
            ViewBag.Shops = _context.shop.Select(x => x.ShopName).ToList();
        }
    }
}