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
        Dictionary<string, double> shopsAndPrices= new Dictionary<string, double>();
      
        public Item(string name, string shopName, double price)
        {
            Name = name;
            shopsAndPrices.Add(shopName, price);
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
            if(shopsAndPrices.ContainsKey(shopName))
            {
                shopsAndPrices[shopName] = price;
            }
            else
            {
                shopsAndPrices.Add(shopName, price);
            }
        }

        public KeyValuePair<string, double> CheapestPrice()
        {
            return shopsAndPrices.OrderBy(key => key.Value).First();
        }
    }
}
