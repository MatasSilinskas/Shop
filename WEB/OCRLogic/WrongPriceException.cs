using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.OCRLogic
{
    public class WrongPriceException : FormatException
    {
        public string Price;

        public WrongPriceException(string price)
        {
            Price = price;
        }
    }
}