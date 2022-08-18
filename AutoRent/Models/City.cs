using AutoRent.Models.CommonProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Models
{
    public class City : SharedProp
    {
        public int CityId { get; set; }

        [Display(Name = "City Name")]
        [Required(ErrorMessage = "Please Enter City Name")]
        public string CityName { get; set; }
    }
}
