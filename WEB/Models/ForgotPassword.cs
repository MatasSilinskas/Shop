using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class ForgotPassword
    {
        [Key]
        [Required(ErrorMessage = "Email is required!")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email address!")]
        public string Email { get; set; }
    }
}