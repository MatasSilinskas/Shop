using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class Receipt
    {
        [Key]
        public int ReceiptID { get; set; }
        public string ShopName { get; set; }
        public double Value { get; set; }
        public DateTime DatePurchased { get; set; }
        public TimeSpan TimePurchased { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}