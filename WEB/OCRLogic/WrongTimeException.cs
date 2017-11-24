using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.OCRLogic
{
    public class WrongTimeException : FormatException
    {
        public string scannedText;

        public WrongTimeException(string scannedInput)
        {
            scannedText = scannedInput;
        }
    }
}