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
        ItemContainer top5 = new ItemContainer();
        string _user;

        public TopFive(string username)
        {
            _user = username;
        }

        public ItemContainer ObtainData()
        {
            string[] readLines = File.ReadAllLines(@"../../../BackendLogic/Accounts/" + _user + ".txt");

            if (readLines.Length > 5)
            {    
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
                    catch (Exception)
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

                var dictTop5 = (from item in items
                                orderby item.Value.AmountOfTimesBought descending
                                select item).Take(5);

                foreach (var item in dictTop5)
                {
                    top5.Add(item.Value);
                }
                return top5;
            }
            else
            {
                return null;
            }
        }
    }
}
