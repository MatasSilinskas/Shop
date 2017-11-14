using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class Receipt
    {
        public string ShopName { get; set; }
        public HttpPostedFileBase Content { get; set; }
    }
}