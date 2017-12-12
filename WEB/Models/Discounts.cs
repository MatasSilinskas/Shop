using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class Discounts
    {
        [Key]
        public int ItemId { get; set; }

        public string ItemName { get; set; }
        
        public string Discount { get; set; }

        [Display(Name = "Price before discount (optional)")]
        public double? PriceBefore{ get; set; }

        [Display(Name = "Price now (optional)")]
        public double? PriceAfter { get; set; }

        public DateTime DateCreated
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value.Date
                   : DateTime.Today.Date;
            }

            set { dateCreated = value; }
        }

        private DateTime? dateCreated = null;

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int TimesReported { get; set; }

        [Display(Name = "Additional information (optional)")]
        public string MoreInfo { get; set; }
        public virtual Shop Shop { get; set; }
    }
}