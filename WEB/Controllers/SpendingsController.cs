using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Interfaces;
using WEB.Models;
using WEB.SpendingsLogic;

namespace WEB.Controllers
{
    public class SpendingsController : Controller
    {
        private readonly IUserAccountDbContext _context;
        public SpendingsController(IUserAccountDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            SpendLogic spendLogic = new SpendLogic(Convert.ToInt32(Session["UserID"]),_context);
            ViewBag.Year = spendLogic.userSpentPerPeriod("year");
            ViewBag.Month = spendLogic.userSpentPerPeriod("month");
            ViewBag.Day = spendLogic.userSpentPerPeriod("week");
            if (spendLogic.userHasLimitsSet())
            {
                return View(spendLogic.getUserSpendings());
            } else
            {
                Spending spend = new Spending();
                spendLogic.getUser().Spending = spend;
                _context.SaveChanges();
                return View(spendLogic.getUserSpendings());
            }
        }

        [HttpPost]
        public ActionResult Index(Spending userSpending)
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            var user = _context.userAccount.Where(x => x.UserID == userID).FirstOrDefault();
            user.Spending.WeeklyLimit = userSpending.WeeklyLimit;
            user.Spending.MonthlyLimit = userSpending.MonthlyLimit;
            user.Spending.YearlyLimit = userSpending.YearlyLimit;
            _context.SaveChanges();
            return Index();
        }

        protected override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            //lets say you set session value to a positive integer
            var LoginType = Convert.ToInt32(filterContext.HttpContext.Session["UserID"]);
            if (LoginType == 0)
            {
                filterContext.HttpContext.Response.Redirect(url: "~/");
            }

            base.OnAuthorization(filterContext);
        }
    }
}