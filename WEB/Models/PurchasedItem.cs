using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class PurchasedItem
    {
        [Key]
        public int PurchasedItemId { get; set; }

        [Display(Name = "Shop")]
        public string ShopName { get; set; }

        [Display(Name = "Item")]
        public string ItemName { get; set; }

        public double Price { get; set; }

        public bool IsChecked { get; set; }

        [Display(Name = "Bought at")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public string Category { get; set; }

        public string Contains { get; set; }

        public bool? IsHealthy { get; set; }

        public virtual UserAccount User { get; set; }
    }
    
 
}