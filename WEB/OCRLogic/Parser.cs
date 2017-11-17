using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WEB.Models;

namespace WEB.OCRLogic
{
    public static class Parser
    {
        public static string pattern = @"\s*-?\d{1,4}\s*,\s*\d{0,3}\s*A\s*$";
        public static string divisionpattern = @"\d{1,3}\s*,\s*\d{0,3}";

        public static void CreateProductsFromString(string input, Int32 id)
        {
            string[] items = input.Split('\n');
            using (var db = new UserAccountDbContext())
            {
                foreach (var item in items)
                {
                    PurchasedItem purchased = new PurchasedItem();
                    Match m = Regex.Match(item, pattern);
                    string[] divided = Regex.Split(item, divisionpattern);
                    purchased.ItemName = divided[0];
                    string fixedValue = m.ToString().Replace("A", "").Replace(" ", "").Replace("\r", "");
                    //Hardcoded for now
                    purchased.ShopName = "IKI";
                    purchased.Price = Double.Parse(fixedValue);
                    purchased.Date = DateTime.Now;
                    purchased.UserId = id;
                    db.purchasedItem.Add(purchased);
                    db.SaveChanges();

                }
            }
        }

    }
}