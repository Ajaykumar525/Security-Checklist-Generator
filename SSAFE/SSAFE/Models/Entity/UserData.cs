using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSAFE.Models.Entity
{
    public class UserData
    {
        public Guid userId { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is required")]
        public string userName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Confirm_Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string ProfilePicture { get; set; }
        public string ConfirmPassword { get; set; }
        public string RoleName { get; set; }
    }
}