using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using WEB.Models;
using WEB.Interfaces;

namespace WEB.OCRLogic
{
    public class ReceiptCreator
    {

        private static ReceiptCreator _creatorObject;
        private readonly IUserAccountDbContext _context;
        string _datepattern = @"20[0-9]{2}\s*-[0-1][0-9]\s*-\s*[0-1][0-9]";
        string _timepattern = @"[0-2][0-9]\s*:\s*[0-5][0-9]\s*:\s*[0-5][0-9]";
        string _ikipattern = @"(?:\s*UAB\s*PALINK\s*|\s*[iI]{1}[Kk]{1}[iI]{1}\s*)";
        string _pricepattern = @"-?[0-9]{1,4}\s?,\s?[0-9]{0,2}\s?A\s?";

        private ReceiptCreator(IUserAccountDbContext context) {
            _context = context;
        }

        public DateTime returnDate(string scannedtext)
        {
            Match match = Regex.Match(scannedtext, _datepattern);
            string date = match.Value;
            return DateTime.Parse(date).Date;
        }

        public TimeSpan returnTime(string scannedtext)
        {
            Match match = Regex.Match(scannedtext, _timepattern);
            string time = match.Value;
            return DateTime.Parse(time).TimeOfDay;
        }

        public string returnShop(string scannedtext)
        {
            Match match = Regex.Match(scannedtext, _ikipattern);
            if (match.Length > 0)
            {
                return "iki";
            } else
            {
                return "n\a";
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
            if (_creatorObject == null)
            {
                _creatorObject = new ReceiptCreator(context);
                return _creatorObject;
            }
            else
            {
                return _creatorObject;
            }
        }
    }
}