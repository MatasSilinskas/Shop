using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.Models;

namespace WEB.SettingsLogic
{
    public class SaveRating
    {
        string _shopName;
        int _rating;
        double _avg = 0;
        public SaveRating(string shopName, int rating)
        {
            _shopName = shopName;
            _rating = rating;
        }
        public void OnRatingAdded(object source, EventArgs args)
        {
            using (UserAccountDbContext db = new UserAccountDbContext())
            {
                Shop item = new Shop();
                item.Rating = _rating;
                item.ShopName = _shopName;
                db.shop.Add(item);
                db.SaveChanges();
            }

        }
    }
}