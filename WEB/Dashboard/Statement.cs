using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.Dashboard
{
    public class Statement
    {
        DateTime _date;
        string _shopName;
        private readonly IUserAccountDbContext _context;
        public Statement(IUserAccountDbContext context, DateTime date, string shopName)
        {
            _date = date;
            _shopName = shopName;
            _context = context;
        }
        public PurchaseList ShowStatement(string submitButton, int UserID)
        {
            PurchaseList purchaseList = new PurchaseList();
            PurchasedItem purchasedItem = new PurchasedItem();
            switch (submitButton)
            {
                case "Show My Statement":
                    purchaseList.fullPrice = 0;
                    purchaseList.listOfProducts = _context.purchasedItem.ToList<PurchasedItem>().Where(x => x.Date >= _date && x.UserId == UserID).ToList();
                    foreach (var item in purchaseList.listOfProducts)
                    {
                        purchaseList.fullPrice += item.Price;
                    }
                    return (purchaseList);
                case "Filter By Shop":
                    purchaseList.fullPrice = 0;
                    purchaseList.listOfProducts = _context.purchasedItem.ToList<PurchasedItem>().Where(x => x.Date >= _date && x.ShopName == _shopName && x.UserId == UserID).ToList();
                    foreach (var item in purchaseList.listOfProducts)
                    {
                        purchaseList.fullPrice += item.Price;
                    }
                    return (purchaseList);
                default: return(purchaseList);
            }
        }
    }

}

  