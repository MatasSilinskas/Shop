using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using WEB.Interfaces;

namespace WEB.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }
 
        [Required(ErrorMessage = "Name is required!")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email address!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password Confirmation is required!")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
        
        public virtual List<PurchasedItem> PurchasedItems { get; set; }
    }
}