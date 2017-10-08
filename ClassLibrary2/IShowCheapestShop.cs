using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    interface IShowCheapestShop
    {
        List<string> itemsFromList { get; }
        string[] readLines { get; }
        double CalculatePrice(string store);
        void FindCheapestStore();
        string ReturnStoreName();
        double ReturnPrice();
    }
}
