using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.OCRLogic
{
    public class WrongDateException : FormatException
    {
        public string scannedText;

        public WrongDateException(string scannedInput)
        {
            scannedText = scannedInput;
        }
    }
}