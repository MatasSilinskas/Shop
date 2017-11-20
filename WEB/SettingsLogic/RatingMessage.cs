using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.Models;
using static WEB.SettingsLogic.RatingAdd;

namespace WEB.SettingsLogic
{
    public class RatingMessage
    {
        string _shopName;
        string _message;
        double _avg;
        int _sum = 0;
        int _count = 0;
        public RatingMessage(string shopName)
        {
            _shopName = shopName;
        }
        public string ReturnMessage()
        {
            return _message;
        }
        public void OnRatingAdded(object source, EventArgs args)
        {
            using (UserAccountDbContext db = new UserAccountDbContext())
            {
                foreach (var item in db.shop)
                {
                    if (item.ShopName == _shopName)
                    {
                        _sum += item.Rating;
                        _count++;
                    }  
                }
                try
                {
                    _avg = Math.Round((double)_sum/(double)_count, 2);
                }
                catch (Exception e)
                {
                    _message = "add a rating";
                }
                
                _message = "Your rating has been added; " + "Average rating of this shop is: " + _avg.ToString() + "; It has been rated " + _count.ToString() + " times" ;
            }
        }
    }
}