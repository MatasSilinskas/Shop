using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class PurchaseList
    {
        public List<PurchasedItem> listOfProducts { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [Display(Name = "Shop name")]
        public string name { get; set; }

        public double fullPrice { get; set; }
        
    }
}