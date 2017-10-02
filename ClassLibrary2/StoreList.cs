using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class StoreList
    {
        List <string> _itemsFromList;
        string[] data;
        string _pathToDatabase = @"../../" + "database.txt";
        public StoreList (List <string> list)
        {
            _itemsFromList = list;
        }
        public string SearchDatabase()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            List<string> Stores = new List<string>();
            string line;
            int i = 0;
            int count = 0;
            string store = "";
            float price = 0f;
            while (i<_itemsFromList.Count())
            {
                System.IO.StreamReader file = new System.IO.StreamReader(_pathToDatabase);
                while((line = file.ReadLine()) != null)
                {
                     data = line.Split('/');
                     if(_itemsFromList[i]==data[2])
                     {
                        if (price==0)
                        {
                            store = data[1];
                            price = float.Parse(data[3]);
                        }
                        else if (price>float.Parse(data[3]))
                        {
                            store = data[1];
                            price = float.Parse(data[3]);
                        }
                     }
                }
                if (store!="")
                {
                    Stores.Add(store);
                    count++;
                }
                store = "";
                price = 0f;
                i++;
            }
            if (count==0)
            {
                return "too little data in database. please try again after scanning a check";
            }
            else
            {
                string j;
                var groupsWithCounts = from s in Stores
                                       group s by s into g
                                       select new
                                       {
                                           Item = g.Key,
                                           Count = g.Count()
                                       };

                var groupsSorted = groupsWithCounts.OrderByDescending(g => g.Count);
                string mostFrequest = groupsSorted.First().Item;
                return mostFrequest;
            }
            
           
        }
    }
}
