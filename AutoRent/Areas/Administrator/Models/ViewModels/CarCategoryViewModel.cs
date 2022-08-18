using AutoRent.Models.CommonProp;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Areas.Administrator.Models.ViewModels
{
    public class CarCategoryViewModel : SharedProp
    {
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Please Enter Category Name")]
        public string CategoryName { get; set; }
        public IFormFile CategoryLogo { get; set; }
    }
}
