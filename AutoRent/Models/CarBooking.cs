using AutoRent.Models.CommonProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Models
{
    public class CarBooking : SharedProp
    {
        [Key]
        [Display(Name = "Booking Reference")]
        [Required]
        public Guid BookingId { get; set; }

        [Display(Name = "Car")]
        [Required(ErrorMessage = "Please Select a Car To Book")]
        public int CarId { get; set; }
        public Car Car { get; set; }

        public ApplicationUser applicationUser { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Please Select Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "Please Select End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Pickup City")]
        [Required(ErrorMessage = "Please Select Pickup City")]
        public int PickupCityId { get; set; }
        public City PickupCity { get; set; }
        [Display(Name = "Pickup Location")]
        [Required(ErrorMessage = "Please Select Pickup Location")]
        public string PickupLocation { get; set; }

        [Display(Name = "Dropoff City")]
        [Required(ErrorMessage = "Please Select Dropoff City")]
        public int DropoffCityId { get; set; }
        //public City DropoffCity { get; set; }

        [Display(Name = "Dropoff Location")]
        [Required(ErrorMessage = "Please Select Location")]
        public string DropoffLocation { get; set; }

        [Display(Name = "Payment Method")]
        [Required(ErrorMessage = "Please Select Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
    }
    public enum PaymentMethod
    {
        Cash, Online
    }
}
