using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.OCRLogic
{
    public class WrongShopException : FormatException
    {
        public string scannedText;

        public WrongShopException(string scannedInput)
        {
            scannedText = scannedInput;
        }
    }
}