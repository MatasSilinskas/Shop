using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WEB.Models
{
    public class ListModel
    {
        [Required(ErrorMessage = "Please add some items")]
        public string SelectedItem { get; set; }
        public SelectList mylist { get; set; }
        
    }
}