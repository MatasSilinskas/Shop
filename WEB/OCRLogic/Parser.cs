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
        int totalItems;
        string _username;
        static Parser _instance;
        public static string pattern = @"\s*-?\d{1,4}\s*,\s*\d{0,3}\s*A\s*$";
        public static string divisionpattern = @"\d{1,3}\s*,\s*\d{0,3}";
        public delegate void OCRdelegate(object sender, OCRFiredEventArgs e);
        public event OCRdelegate OCRFired;

        private Parser() { }

        public void CreateProductsFromString(string input, string username)
        {
            _username = username;
           string[] items = input.Split('\n');
           totalItems = items.Length;

            try
            {
                this.CreateItems(items,username);

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

        private void CreateItems(string[] items, string username)
        {
            using (var db = new UserAccountDbContext())
            {
                var user = db.userAccount.Where(u => u.Username == username).FirstOrDefault();

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
                    purchased.UserId = user.UserID;
                    db.purchasedItem.Add(purchased);
                    db.SaveChanges();

                }
               
                OnOCRFired(this, new OCRFiredEventArgs(totalItems.ToString(), user.Username));
            }
        }

    }
}