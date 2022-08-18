using AutoRent.Models.CommonProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Models
{
    public class CarCategory : SharedProp
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Please Enter Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Category Logo")]
        [Required(ErrorMessage = "Please Enter Category Logo")]
        public string CategoryLogo { get; set; }
    }
}
