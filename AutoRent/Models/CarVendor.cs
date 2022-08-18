using AutoRent.Models.CommonProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Models
{
    public class CarVendor : SharedProp
    {
        [Key]
        public int VendorId { get; set; }

        [Display(Name = "Vendor Name")]
        [Required(ErrorMessage = "Please Enter Vendor Name")]
        public string VendorName { get; set; }

        [Display(Name = "Vendor Logo")]
        [Required(ErrorMessage = "Please Enter Vendor Logo")]
        public string VendorLogo { get; set; }
    }
}
