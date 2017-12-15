using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.Interfaces;

namespace WEB.SpendingsLogic
{
    public class SpendLogic
    {
        private readonly IUserAccountDbContext _context;
        private int _userid;


        public SpendLogic(int userid, IUserAccountDbContext context)
        {
            _context = context;
            _userid = userid;
        }
        public int DayOfWeek() => (int)(DateTime.Today.DayOfWeek + 6) % 7;

        public int DayOfMonth() => DateTime.Today.Day;

        public int DayOfYear() => DateTime.Today.DayOfYear;

        public bool userHasLimitsSet()
        {
            var user = _context.spendings.Where(x => x.UserAccount.UserID == _userid).FirstOrDefault();
            return user == null ? true : false;
        }

        public Models.Spending getUserSpendings()
        {
            return _context.spendings.Where(x => x.UserAccountID == _userid).FirstOrDefault();
        }

        public double userSpentPerPeriod(string period)
        {
            DateTime weekStart;
            switch (period)
            {
                case "week": weekStart = DateTime.Today.AddDays(-1 * ((double)DayOfWeek()));
                break;

                case "month": weekStart = DateTime.Today.AddDays(-1 * ((double)DayOfMonth()));
                break;

                case "year": weekStart = DateTime.Today.AddDays(-1 * ((double)DayOfYear()));
                break;

                default: weekStart = DateTime.Today;
                break;
            }
            var userReceipts = _context.receipt
           .Where(x => x.UserId == _userid)
           .Select(x => new { x.UserId, x.DatePurchased, x.TimePurchased, x.Value })
           .Where(x => x.DatePurchased >= weekStart)
           .GroupBy(x => new { x.UserId, x.DatePurchased, x.TimePurchased, x.Value })
           .Sum(x => (double?)x.Key.Value) ?? 0;
            return userReceipts;
        }
    }
}