using AutoRent.Models;
using AutoRent.Models.CommonProp;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Areas.Company.Models.ViewModels
{
    public class CarViewModel:SharedProp
    {
        public int CarId { get; set; }

        [Required]
        public string CompanyId { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please Select Car Category")]
        public int CategoryId { get; set; }

        public CarCategory carCategory { get; set; }

        [Display(Name = "Vendor")]
        [Required(ErrorMessage = "Please Select Car Vendor")]
        public int VendorId { get; set; }

        public CarVendor carVendor { get; set; }

        [Display(Name = "Car Description")]
        public string CarDesc { get; set; }

        [Display(Name = "Plate No")]
        [Required(ErrorMessage = "Please Enter Car Plate No")]
        public string PlateNo { get; set; }

        [Display(Name = "Production Year")]
        [Required(ErrorMessage = "Please Select Production Year")]
        public int ProdYear { get; set; }

        public string Color { get; set; }

        [Display(Name = "No Of Seats")]
        [Required(ErrorMessage = "Please Select No Of Seats")]
        public int SeatNo { get; set; }

        [Display(Name = "No Of Doors")]
        [Required(ErrorMessage = "Please Select No Of Doors")]
        public int DoorNo { get; set; }

        [Display(Name = "Is Condishended?")]
        public bool IsCondishended { get; set; }

        [Display(Name = "Gear Type")]
        [Required(ErrorMessage = "Please Select Gear Type")]
        public GearType GearType { get; set; }

        public IFormFile CarLogo { get; set; }

        [Display(Name = "Booking Price/Day")]
        public double Price { get; set; }
    }
}
