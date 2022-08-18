using AutoRent.Models.CommonProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Models
{
    public class CarReview : SharedProp
    {
        [Key]
        public int ReviewId { get; set; }

        public CarBooking CarBooking { get; set; }

        [Display(Name = "Review Date")]
        [Required(ErrorMessage = "Please Select Review Date")]
        public DateTime ReviewDate { get; set; }

        [Display(Name = "Rate")]
        public int Rate { get; set; }

        [Display(Name = "Review Description")]
        [DataType(DataType.MultilineText)]
        public string ReviewDesc {get; set;}

        public ApplicationUser applicationUser { get; set; }
    }
}
