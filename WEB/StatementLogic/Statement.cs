using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.StatementLogic
{
    public class Statement
    {
        private readonly IUserAccountDbContext _context;
        DateTime _date;
        string shopName;
        PurchaseList purchaseList = new PurchaseList();
        PurchasedItem purchasedItem = new PurchasedItem();
        public delegate void StatementMthd(int userID, string submitButton);
        public Statement(IUserAccountDbContext context, PurchaseList datemodel)
        {
            _context = context;
            _date = datemodel.date;
            shopName = datemodel.name;
        }
        public void ShowMyStatement(StatementMthd mthd, int userId, string submitButton)
        {
            if(submitButton == "Show My Statement")
            {
                purchaseList.listOfProducts = _context.purchasedItem.ToList<PurchasedItem>().Where(x => x.Date >= _date && x.UserId == userId).ToList();
                mthd();
            }
            
        }
        public void FilterByShop(int userId, string submitButton)
        {
            if (submitButton == "Filter By Shop")
            {
                purchaseList.fullPrice = 0;
                purchaseList.listOfProducts = _context.purchasedItem.ToList<PurchasedItem>().Where(x => x.Date >= _date && x.ShopName == shopName && x.UserId == userId).ToList();
                foreach (var item in purchaseList.listOfProducts)
                {
                    purchaseList.fullPrice += item.Price;
                }
            }
        }
    }
}