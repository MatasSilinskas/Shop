using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class Shop
    {
        [Key]
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public int Rating { get; set; }
    }
}