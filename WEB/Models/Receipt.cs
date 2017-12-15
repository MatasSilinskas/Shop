using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("UserAccount")]
        public int UserId { get; set; }

        public virtual UserAccount UserAccount { get; set; }
    }
}