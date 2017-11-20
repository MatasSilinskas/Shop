using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.OCRLogic
{
    public class OCRFiredEventArgs : EventArgs
    {

        public string TotalItems { get; set; }
        public string UserName { get; set; }

        public OCRFiredEventArgs(string totalItems, string username)
        {
            TotalItems = totalItems;
            UserName = username;
        }
    }
}