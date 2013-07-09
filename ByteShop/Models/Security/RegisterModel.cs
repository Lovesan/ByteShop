using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ByteShop.Models.Security
{
    public class RegisterModel
    {
        [Required]
        [Display(Name="Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name="Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name="Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name="Birth date")]
        public DateTime BirthDate { get; set; }
    }
}