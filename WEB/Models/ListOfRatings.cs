using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    
    public class Ratings
    {
        public string rating { get; set; }
        public bool isChecked { get; set; }
    }
    public class ListOfRatings
    {
        public string shopToRate { get; set; }
        public List<Ratings> list { get; set; }
    }
}