using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{

    public class Items : IList<Item>
    {
        private List<Item> _items = new List<Item>();
        private List<string> _allShopNames = new List<string>();
        private string _warning = "";
        public string Warning { get { return _warning; } }

        public Item this[int index] {
            get { return _items[index]; }
            set { _items[index] = value; }
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(Item item)
        {
            _items.Add(item);
            
            foreach(var shop in item.ShopsAndPrices)
            {
                if(!_allShopNames.Contains(shop.Key))
                {
                    _allShopNames.Add(shop.Key);
                }
            }    
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(Item item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public int IndexOf(Item item)
        {
            return _items.IndexOf(item);
        }

        public void Insert(int index, Item item)
        {
            _items.Insert(index, item);
        }

        public bool Remove(Item item)
        {
            return _items.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /* Makes a dictionary of shop names and how much has been spent in them
         * if a specific item wasn`t bought in a specific shop, approximate price of the item is calculated
         * and warning message is updated with the information of about that item */
        public KeyValuePair<string, double> ShopRecommendation()
        {
            var shops = new Dictionary<string, double>();
            var itemsNotBought = new Dictionary<string, List<string>>();

            foreach (string shop in _allShopNames)
            {
                shops.Add(shop, 0);
                foreach(Item item in _items)
                {
                    if(item.ShopsAndPrices.ContainsKey(shop))
                    {
                        shops[shop] += item.ShopsAndPrices[shop];
                    }
                    else
                    {
                        double approxPrice = 0;
                        foreach(var price in item.ShopsAndPrices)
                        {
                            approxPrice += price.Value;
                        }
                        shops[shop] += approxPrice / item.ShopsAndPrices.Count;
                        if(!itemsNotBought.ContainsKey(item.Name))
                        {
                            itemsNotBought.Add(item.Name, new List<string>());
                        }
                        itemsNotBought[item.Name].Add(shop);
                    }
                }
            }
            FormatWarningMessage(itemsNotBought);

            return shops.OrderBy(key => key.Value).First();
        }

        private void FormatWarningMessage(Dictionary<string, List<string>> itemsNotBought)
        {
            if (itemsNotBought.Count > 0)
            {
                _warning = "\nNOTE: The displayed information may be incorrect because " +
                    "the following items haven`t been bought in these shops: ";
                foreach(var item in itemsNotBought)
                {
                    _warning += "\n" + item.Key + ":";
                    foreach(var shopName in item.Value)
                    {
                        _warning += shopName;
                    }
                }
            }
        }
    }
}
