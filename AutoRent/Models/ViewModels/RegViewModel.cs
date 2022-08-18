using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Models.ViewModels
{
    public class RegViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "User Password")]
        [Required(ErrorMessage = "Please Enter User Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm User Password")]
        [Required(ErrorMessage = "Please Enter Confirm User Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password And Confirm Not Matched!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Enter Your Mpobile/Phone No.")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please Enter Your Detailed Address")]
        public string Address { get; set; }

        [Display(Name = "ID/Passport Image")]
        [Required(ErrorMessage = "Please Enter Image for your ID Card or Your Passport")]
        public IFormFile IDImage { get; set; }
        
        [Required(ErrorMessage = "Please Select Your Gender")]
        public AutoRent.Models.Gender Gender { get; set; }
    }
    
}
