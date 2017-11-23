using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.Interfaces;
using WEB.Models;
using static WEB.SettingsLogic.RatingChosenEvent;

namespace WEB.SettingsLogic
{
    public class RatingMessageHandle
    {
        string _shopName;
        string _message;
        double _avg;
        int _sum = 0;
        int _count = 0;
        private readonly IUserAccountDbContext _context;
        public RatingMessageHandle(string shopName, IUserAccountDbContext context)
        {
            _shopName = shopName;
            _context = context;
        }
        public string ReturnMessage()
        {
            return _message;
        }
        public void OnRatingAdded(object source, EventArgs args)
        {
            Count();
            if (_message == null)
                _message = "Your rating has been added; " + "Average rating of this shop is: " + _avg.ToString() + "; It has been rated " + _count.ToString() + " times";
        }
        public void Count()
        {
            foreach (var item in _context.shop)
            {
                if (item.ShopName == _shopName)
                {
                    _sum += item.Rating;
                    _count++;
                }
            }
            try
            {
                _avg = Math.Round((double)_sum / (double)_count, 2);
            }
            catch (Exception e)
            {
                _message = "The shop has not been rated yet. Be the first one, slect a rating!";
            }

        }
    }
}