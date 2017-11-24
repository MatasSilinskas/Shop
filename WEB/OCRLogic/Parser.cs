using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WEB.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;

namespace WEB.OCRLogic
{
    public class Parser
    {
        int totalItems;
        string _username;
        static Parser _instance;
        public static string pattern = ConfigurationManager.AppSettings["pattern"];
        public static string divisionpattern = ConfigurationManager.AppSettings["divisionpattern"];
        public delegate void OCRdelegate(object sender, OCRFiredEventArgs e);
        public event OCRdelegate OCRFired;

        private Parser() { }

        public void CreateProductsFromString(Receipt receipt, string username)
        {
            _username = username;
           string[] items = receipt.Content.Split('\n');
           totalItems = items.Length;

            try
            {
                this.CreateItems(items,receipt,username);

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

        private void CreateItems(string[] items, Receipt receipt, string username)
        {
            using (var db = new UserAccountDbContext())
            {
                var user = db.userAccount.Where(u => u.Username == username).FirstOrDefault();


                    foreach (var item in items)
                    {
                    try
                    {
                        PurchasedItem purchased = new PurchasedItem();
                        Match m = Regex.Match(item, pattern);
                        string[] divided = Regex.Split(item, divisionpattern);
                        purchased.ItemName = divided[0];
                        string fixedValue = m.ToString().Replace("A", "").Replace(" ", "").Replace("\r", "").Replace(".", ",");
                        if (fixedValue.Contains("-"))
                        {
                            continue;
                        }
                        purchased.ShopName = receipt.ShopName;
                        purchased.Price = Double.Parse(fixedValue);
                        purchased.Date = receipt.DatePurchased;
                        purchased.UserId = user.UserID;
                        db.purchasedItem.Add(purchased);
                        db.SaveChanges();
                    }
                    catch (FormatException e)
                    {
                        throw new WrongPriceException(item);
                    }
                    }

               
                OnOCRFired(this, new OCRFiredEventArgs(totalItems.ToString(), user.Username));
            }
        }

    }
}