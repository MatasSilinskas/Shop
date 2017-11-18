using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using WEB.Models;

namespace WEB.ShopFromAListLogic
{
    public class FromList
    {
            private List<string> _itemsFromList;
            string _name;
            DateTime _date;
            double _price;
            Dictionary<string, double> Stores = new Dictionary<string, double>();        
            public FromList(List<string> list, DateTime date)
            {
                _itemsFromList = list;
                _date = date;
            }
            public void AssignStoresAndPrices()
            {
            using (UserAccountDbContext db = new UserAccountDbContext())
            {
                foreach (var item in db.purchasedItem)
                {
                    if (!Stores.ContainsKey(item.ShopName))
                    {
                        Stores.Add(item.ShopName, CalculatePrice(item.ShopName));
                    }
                }
            }
            }
            public double CalculatePrice(string store)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
                double price = 0;
                int foundItemsInStore = 0;
                int count = _itemsFromList.Count();
                List<string> items = new List<string>(_itemsFromList);
                using (UserAccountDbContext db = new UserAccountDbContext())
                {
                   
                    foreach (var item in db.purchasedItem)
                    {
                        if ((store == item.ShopName) && (items.Contains(item.ItemName)) && (_date <= item.Date))
                        {
                            price += item.Price;
                            foundItemsInStore++;
                            items.Remove(item.ItemName);
                        }
                    }
                    if (count == foundItemsInStore)
                        return price;
                    else return 0;
                }
                
            }
            public void FindCheapestStore()
            {
                AssignStoresAndPrices();
                var storeMinValue = Stores.Min(x => x.Value);
                var storeMaxValue = Stores.Max(x => x.Value);
                if (storeMinValue != 0)
                {
                    _name = Stores.FirstOrDefault(x => x.Value == storeMinValue).Key;
                    _price = storeMinValue;
                }
                else if (storeMinValue == storeMaxValue)
                {
                    _name = "Too little data in database. Please try again after scanning a check.";
                    _price = 0;
                }
                else
                {
                    _name = Stores.FirstOrDefault(x => x.Value != 0).Key;
                    _price = Stores.FirstOrDefault(x => x.Value != 0).Value;
                }
            }
            public string ReturnStoreName()
            {
                FindCheapestStore();
                return _name;
            }
            public double ReturnPrice()
            {
                FindCheapestStore();
                return _price;
            }

        }
    
}