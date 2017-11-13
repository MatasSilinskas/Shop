using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class PurchasedItem
    {
        public int PurchasedItemId { get; set; }
        public string ShopName { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public virtual UserAccount User { get; set; }
    }
}