using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Models.ViewModels
{
    public class LoginViewModel
    {

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; }

        [Display(Name = "User Password")]
        [Required(ErrorMessage = "Please Enter User Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Please Remember Me")]
        public bool RememberMe { get; set; }
    }
}
