using AutoRent.Models.CommonProp;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Areas.Administrator.Models.ViewModels
{
    public class CarVendorViewModel:SharedProp
    {
        public int VendorId { get; set; }

        [Display(Name = "Vendor Name")]
        [Required(ErrorMessage = "Please Enter Vendor Name")]
        public string VendorName { get; set; }

        public IFormFile VendorLogo { get; set; }
    }
}
