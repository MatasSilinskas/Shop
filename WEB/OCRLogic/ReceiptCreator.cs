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
        string _rimipattern = ConfigurationManager.AppSettings["rimipattern"];
        string _maximapattern = ConfigurationManager.AppSettings["maximapattern"];
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
            Match rimimatch = Regex.Match(scannedtext, _rimipattern);
            Match maximamatch = Regex.Match(scannedtext, _maximapattern);
            if (match.Length > 0)
            {
                return ConfigurationManager.AppSettings["iki"];

            } else
            {
                if (rimimatch.Length > 0)
                {
                    return ConfigurationManager.AppSettings["rimi"];
                }
                else
                {
                    if (maximamatch.Length > 0)
                    {
                        return ConfigurationManager.AppSettings["maxima"];
                    }
                    else
                    {
                        throw new WrongShopException(scannedtext);
                    }   
                }
            }
        }

        public double returnPrice(string scannedtext)
        {
            Regex rule = new Regex(_pricepattern);
            List<double> prices = new List<double>();
            var matches = rule.Matches(scannedtext);
            foreach (var match in matches)
            {
                double price = Double.Parse(match.ToString().Replace("A", "").Replace(" ", "").Replace(",","."));
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
            receipt.Content = FilterContent(scannedtext, receipt.ShopName);
            receipt.UserId = userID;
            receipt.Value = this.returnPrice(scannedtext);
            return receipt;
        }

        private string FilterContent(string scannedtext, string detectedshop)
        {
            if (detectedshop == ConfigurationManager.AppSettings["rimi"])
            {
                return RimiShopParsing(scannedtext);
            } else
            {
                if (detectedshop == ConfigurationManager.AppSettings["iki"])
                {
                    return IkiShopParsing(scannedtext);
                }
                else
                {
                    return scannedtext;
                }
            }
        }

        public List<string> PricesParsing(string text, bool checkForNegatives)
        {
            List<string> tempPricesOutput = new List<string>();
            Regex fetchAllPrices = new Regex(ConfigurationManager.AppSettings["pricespattern"]);
            Regex discardNegativePrices = new Regex(ConfigurationManager.AppSettings["negativeprices"]);
            foreach (var occurence in fetchAllPrices.Matches(text))
            {

                    if (Regex.IsMatch(occurence.ToString(), ConfigurationManager.AppSettings["negativeprices"]) && checkForNegatives)
                    {
                        continue;
                    }
                    else
                    {
                        tempPricesOutput.Add(occurence.ToString());
                    }

            }
            return tempPricesOutput;
        }

        public string IkiShopParsing(string scannedtext)
        {
            List<string> tempPricesOutput = PricesParsing(scannedtext,false);
            List<string> productsOutput = new List<string>();
            string temp = String.Empty;
            Regex fetchAllPrices = new Regex(ConfigurationManager.AppSettings["pricespattern"]);
            Regex ikiBegin = new Regex(ConfigurationManager.AppSettings["ikibeginpattern"]);
            Regex ikiEnd = new Regex(ConfigurationManager.AppSettings["ikiendpattern"]);

            temp = fetchAllPrices.Replace(scannedtext, "\n");
            int start = ikiBegin.Match(temp).Index + ikiBegin.Match(temp).Length;
            temp = temp.Substring(start, ikiEnd.Match(temp).Index - start);

            string final = String.Empty;
            foreach (var product in temp.Split('\n'))
            {
                productsOutput.Add(product);
            }
            int tempvar = 0;
            foreach (var product in productsOutput)
            {
                try
                {
                    final += product + tempPricesOutput[tempvar];
                }
                catch (ArgumentOutOfRangeException e)
                {
                    final += product;
                    tempvar++;
                }
                tempvar++;
            }

            return final;
        }
        public string RimiShopParsing(string scannedtext)
        {
            List<string> tempPricesOutput = PricesParsing(scannedtext,true);
            List<string> productsOutput = new List<string>();
            string temp = String.Empty;
            Regex fetchAllPrices = new Regex(ConfigurationManager.AppSettings["pricespattern"]);
            Regex rimiBegin = new Regex(ConfigurationManager.AppSettings["rimibeginpattern"]);
            Regex rimiEnd = new Regex(ConfigurationManager.AppSettings["rimiendpattern"]);
            Regex rimiDiscounts = new Regex(ConfigurationManager.AppSettings["rimidiscountspattern"]);

            temp = fetchAllPrices.Replace(scannedtext, "\n");
            int start = rimiBegin.Match(temp).Index + rimiBegin.Match(temp).Length;
            temp = temp.Substring(start, rimiEnd.Match(temp).Index - start);
            temp = rimiDiscounts.Replace(temp, "\n");
            string final = String.Empty;
            foreach(var product in temp.Split('\n'))
            {
                productsOutput.Add(product);
            }
            int tempvar = 0;
            foreach (var product in productsOutput) 
            {
                try
                {
                    final += product + tempPricesOutput[tempvar];
                } catch(ArgumentOutOfRangeException e)
                {
                    final += product;
                    tempvar++;
                }
                tempvar++;
            }
            return final;
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