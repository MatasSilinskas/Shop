using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Item
    {
        public string Name { get; }
        public int AmountOfTimesBought { get; set; } = 1;
        public Dictionary<string, double> ShopsAndPrices { get; set; } = new Dictionary<string, double>();
      
        public Item(string name, string shopName, double price)
        {
            Name = name;
            ShopsAndPrices.Add(shopName, price);
        }

        public override string ToString()
        {
            return Name;
        }

        /* adds a new price and shop if they didnt exist yet 
         * else, set a new price in that shop
         * alwyas increases the amount of times the product was bought */
        public void BoughtAgain(string shopName, double price)
        {
            AmountOfTimesBought++;
            if(ShopsAndPrices.ContainsKey(shopName))
            {
                ShopsAndPrices[shopName] = price;
            }
            else
            {
                ShopsAndPrices.Add(shopName, price);
            }
        }

        public KeyValuePair<string, double> CheapestPrice()
        {
            return ShopsAndPrices.OrderBy(key => key.Value).First();
        }
    }
}
