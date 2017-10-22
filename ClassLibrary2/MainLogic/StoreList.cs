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
        Split split = new Split();
        string _name;
        DateTime _date;
        double _price;
        Dictionary<string, double> Stores = new Dictionary<string, double>();
        static string _pathToDatabase = @"../../" + "database.txt";
        static ReadLogic read = new ReadLogic();
        string[] _readLines = read.ReadFile(_pathToDatabase);
        public string[] readLines
        {
            get
            {
                return _readLines;
            }
        }
        public StoreList(List<string> list, DateTime date)
        {
            _itemsFromList = list;
            _date = date;
        }
        public void AssignStoresAndPrices()
        {
            foreach (string line in readLines)
            {
                string[] _data;
                _data = split.SplitLine(line);
                if (!Stores.ContainsKey(_data[1]))
                {
                    Stores.Add(_data[1], CalculatePrice(_data[1]));
                }
            }
        }
        public double CalculatePrice(string store)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            double price = 0;
            int foundItemsInStore = 0;
            string[] _data;
            int count = _itemsFromList.Count();
            List<string> items = new List<string>(_itemsFromList);
            for(int i = readLines.Length-1; i>=0; i--)
            {
                _data = split.SplitLine(readLines[i]);
                if ((store == _data[1]) && (items.Contains(_data[2])) && (_date <= DateTime.Parse(_data[4])))
                {
                    
                    price += double.Parse(_data[3]);
                    foundItemsInStore++;
                    items.Remove(_data[2]);
                }
            }
            if (count == foundItemsInStore)
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
