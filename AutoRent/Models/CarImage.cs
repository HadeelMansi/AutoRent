using AutoRent.Models.CommonProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Models
{
    public class CarImage : SharedProp
    {
        public int CarImageId { get; set; }

        [Display(Name = "Car")]
        [Required(ErrorMessage = "Please Select a Car To Book")]
        public Car Car { get; set; }


        [Display(Name = "Car Image")]
        [Required]
        public string CarImg { get; set; }

    }
}
