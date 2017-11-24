using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.SettingsLogic
{
    public class RatingSaveHandle
    {
        string _shopName;
        int _rating;
        private readonly IUserAccountDbContext _context;
        public RatingSaveHandle(string shopName, int rating, IUserAccountDbContext context)
        {
            _shopName = shopName;
            _rating = rating;
            _context = context;
        }
        public void OnRatingAdded(object source, EventArgs args)
        {
            Shop item = new Shop();
            item.Rating = _rating;
            item.ShopName = _shopName;
            _context.shop.Add(item);
            _context.SaveChanges();

        }
    }
}