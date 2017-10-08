using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class StoreList: IShowCheapestShop
    {
        private List<string> _itemsFromList;
        public List<string> itemsFromList
        {
            get
            {
                return _itemsFromList;
            }
        }
        string[] data;
        string _name;
        double _price;
        Dictionary<string, double> Stores = new Dictionary<string, double>();
        static string _pathToDatabase = @"../../" + "database.txt";
        private string[] _readLines = File.ReadAllLines(_pathToDatabase);
        public string[] readLines
        {
            get
            {
                return _readLines;
            }
        }
        public StoreList(List<string> list)
        {
            _itemsFromList = list;
        }
        public void AssignStoresAndPrices()
        {
            foreach (string line in readLines)
            {
                data = line.Split('/');
                if (!Stores.ContainsKey(data[1]))
                {
                    Stores.Add(data[1], CalculatePrice(data[1]));
                }
            }
        }
        public double CalculatePrice(string store)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            double price = 0;
            int foundItemsInStore = 0;
            foreach (string line in readLines)
            {
                data = line.Split('/');
                if ((store == data[1]) && (_itemsFromList.Contains(data[2])))
                {
                    price += double.Parse(data[3]);
                    foundItemsInStore++;
                }
            }
            if (_itemsFromList.Count() == foundItemsInStore)
                return price;
            else return 0;
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
