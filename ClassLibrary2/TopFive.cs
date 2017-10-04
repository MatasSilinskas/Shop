using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TopFive
    {
        Dictionary<string, Item> items = new Dictionary<string, Item>();    //all bought items
        Items top5 = new Items();
        string _user;

        public TopFive(string username)
        {
            _user = username;
        }

        public Items ObtainData()
        {
            string[] readLines = File.ReadAllLines(@"../../" + _user + ".txt");

            foreach (string line in readLines)
            {
                string[] container = line.Split(' ');

                /* gets the name of the item */
                string itemName = container[1];
                for (int i = 2; i < container.Length - 2; i++)
                {
                    itemName += " " + container[i];
                }
 
                string shopName = container[0];
                double price;
                try
                {
                    price = Convert.ToDouble(container[container.Length - 2].Replace('.', ','));
                }
                catch (Exception e)
                {
                    price = Convert.ToDouble(container[container.Length - 2]);
                }

                if (items.ContainsKey(itemName))
                {
                    items[itemName].BoughtAgain(shopName, price);
                }
                else
                {
                    items.Add(itemName, new Item(itemName, shopName, price));
                }   
            }

            var dictTop5 = items.OrderByDescending(pair => pair.Value.AmountOfTimesBought).Take(5).ToList();
  
            foreach (var item in dictTop5)
            {
                top5.Add(item.Value);
            }

            return top5;
        }

        public string ShopRecommendation()
        {
            var options = new Dictionary<string, int>();
            foreach (Item item in top5)
            {
               if (options.ContainsKey(item.CheapestPrice().Key))
                {
                    options[item.CheapestPrice().Key]++;
                }
               else
                {
                    options.Add(item.CheapestPrice().Key, 1);
                }            
            }
            return options.OrderByDescending(key => key.Value).First().Key;
        }
    }
}
