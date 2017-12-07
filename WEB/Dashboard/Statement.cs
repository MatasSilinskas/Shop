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
        private int _userID;
        private DateTime _date;
        private string _shopName;
        private readonly IUserAccountDbContext _context;
        public Statement(IUserAccountDbContext context, DateTime date, string shopName, int userID)
        {
            _userID = userID;
            _date = date;
            _shopName = shopName;
            _context = context;
        }
        private PurchaseList CalculatePrice(PurchaseList purchaseList)
        {
            purchaseList.fullPrice = 0;
            purchaseList.date = _date;
            purchaseList.listOfProducts.ForEach(item => purchaseList.fullPrice += item.Price);
            return (purchaseList);
        }

        public PurchaseList FilterByShop()
        {
            PurchaseList purchaseList = new PurchaseList
            {
                listOfProducts = _context.purchasedItem.ToList<PurchasedItem>()
                    .Where(x => x.Date >= _date && x.ShopName == _shopName && x.UserId == _userID)
                    .ToList()
            };
            return CalculatePrice(purchaseList);
        }
        public PurchaseList FilterByDate()
        {
            PurchaseList purchaseList = new PurchaseList
            {
                listOfProducts = _context.purchasedItem.ToList<PurchasedItem>()
                    .Where(x => x.Date >= _date && x.UserId == _userID)
                    .ToList()
            };
            return CalculatePrice(purchaseList);
        }
    }
}