using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using WEB.Models;
using System.Configuration;
using WEB.Interfaces;

namespace WEB.OCRLogic
{
    public class ReceiptCreator
    {

        private static ReceiptCreator _creatorObject;
        private readonly IUserAccountDbContext _context;
        string _datepattern = ConfigurationManager.AppSettings["datepattern"];
        string _timepattern = ConfigurationManager.AppSettings["timepattern"];
        string _ikipattern = ConfigurationManager.AppSettings["ikipattern"];
        string _pricepattern = ConfigurationManager.AppSettings["pricepattern"];

        private ReceiptCreator(IUserAccountDbContext context) {
            _context = context;
        }

        public DateTime returnDate(string scannedtext)
        {
            Match match = Regex.Match(scannedtext, _datepattern);
            string date = match.Value;
            try
            {
              return DateTime.Parse(date).Date;
            } catch(FormatException e)
            {
                throw new WrongDateException(scannedtext);
            }
        }

        public TimeSpan returnTime(string scannedtext)
        {
            Match match = Regex.Match(scannedtext, _timepattern);
            string time = match.Value;
            try
            {
              return DateTime.Parse(time).TimeOfDay;
            } catch (FormatException e)
            {
                throw new WrongTimeException(scannedtext);
            }
        }

        public string returnShop(string scannedtext)
        {
            Match match = Regex.Match(scannedtext, _ikipattern);
            if (match.Length > 0)
            {
                return ConfigurationManager.AppSettings["iki"];

            } else
            {
                throw new WrongShopException(scannedtext);
            }
        }

        public double returnPrice(string scannedtext)
        {
            Regex rule = new Regex(_pricepattern);
            List<double> prices = new List<double>();
            var matches = rule.Matches(scannedtext);
            foreach (var match in matches)
            {
                double price = Double.Parse(match.ToString().Replace("A", "").Replace(" ", ""));
                prices.Add(price);
            }
            double totalPrice = 0d;
            foreach(var price in prices)
            {
                totalPrice += price;
            }

            return totalPrice;
        }

        public Receipt CreateReceipt(string scannedtext, int userID)
        {
            Receipt receipt = new Receipt();
            receipt.DatePurchased = this.returnDate(scannedtext);
            receipt.TimePurchased = this.returnTime(scannedtext);
            receipt.ShopName = this.returnShop(scannedtext);
            receipt.Content = scannedtext;
            receipt.UserId = userID;
            receipt.Value = this.returnPrice(scannedtext);

            return receipt;
        }

        public void PutReceipt(string scannedtext, int userID)
        {
            Receipt receipt = this.CreateReceipt(scannedtext, userID);
            _context.receipt.Add(receipt);
            _context.SaveChanges();
        }
        

        public static ReceiptCreator GetReceiptCreator(IUserAccountDbContext context)
        {

               _creatorObject = new ReceiptCreator(context);
                return _creatorObject;
        }
    }
}