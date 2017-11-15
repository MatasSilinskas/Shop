using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class Top5Item
    {
        [Display(Name = "Amount of times bought")]
        public int AmountOfTimesBought { get; set; }


        [Key]
        public string Item { get; set; }

        public double Price { get; set; }

        [Display(Name = "Cheapest at")]
        public string CheapestAt { get; set; }
    }
}