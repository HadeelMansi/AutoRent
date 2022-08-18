using AutoRent.Models.CommonProp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Areas.Administrator.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
        //public int ApplicationRoleId { get; set; }
        public int AdsNo { get; set; }
        public int PicsNo { get; set; }
        public IFormFile RoleImg { get; set; }
        public int OrderNo { get; set; }
        public IdentityRole identityRole { get; set; }
        public double Price { get; set; }
    }
}
