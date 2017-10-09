﻿using System;
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
        Dictionary<string, Item> _items = new Dictionary<string, Item>();    //all bought items
        Items _top5 = new Items();
        string _user;

        public TopFive(string user)
        {
            _user = user;
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

                if (_items.ContainsKey(itemName))
                {
                    _items[itemName].BoughtAgain(shopName, price);
                }
                else
                {
                    _items.Add(itemName, new Item(itemName, shopName, price));
                }   
            }

            var dictTop5 = _items.OrderByDescending(pair => pair.Value.AmountOfTimesBought).Take(5).ToList();
  
            foreach (var item in dictTop5)
            {
                _top5.Add(item.Value);
            }

            return _top5;
        }
    }
}
