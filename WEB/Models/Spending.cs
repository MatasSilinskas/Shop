using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WEB.Interfaces;

namespace WEB.Models
{
    public class Spending
    {
        [Key]
        [ForeignKey("UserAccount")]
        public int UserAccountID { get; set; }
        [Display(Name ="Your Weekly Spending Limit")]
        public int WeeklyLimit { get; set; }
        [Display(Name = "Your Monthly Spending Limit")]
        public int MonthlyLimit { get; set; }
        [Display(Name = "Your Yearly Spending Limit")]
        public int YearlyLimit { get; set;  }

        public virtual UserAccount UserAccount { get; set; }
    }
}