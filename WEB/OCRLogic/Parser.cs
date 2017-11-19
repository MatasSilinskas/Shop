using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WEB.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace WEB.OCRLogic
{
    public class Parser
    {
        static Parser _instance;
        public static string pattern = @"\s*-?\d{1,4}\s*,\s*\d{0,3}\s*A\s*$";
        public static string divisionpattern = @"\d{1,3}\s*,\s*\d{0,3}";
        int totalItems;
        int userid;

        public delegate void OCRdelegate(object sender, OCRFiredEventArgs e);

        public event OCRdelegate OCRFired;

        private Parser() { }

        public void CreateProductsFromString(string input, Int32 id)
        {
           userid = id;
           string[] items = input.Split('\n');
           totalItems = items.Length;

            try
            {
                this.CreateItems(items,id);

            } catch(SqlException e)
            {
                throw new Exception();
            }
        }

        public virtual void OnOCRFired(object sender, OCRFiredEventArgs args)
        {
            OCRFired(sender, args);
        }

        public static Parser GetParserObject()
        {
            if (_instance != null)
            {
                return _instance;
            }
            else
            {
                _instance = new Parser();
                return _instance;
            }
        }

        private void CreateItems(string[] items, int id)
        {
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
                var user = db.userAccount.Where(u => u.UserID == id).FirstOrDefault();
                OnOCRFired(this, new OCRFiredEventArgs(totalItems.ToString(), user.Username));
            }
        }

    }
}