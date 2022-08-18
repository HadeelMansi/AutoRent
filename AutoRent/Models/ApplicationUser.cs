using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string IDImage { get; set; }

    }
    public enum Gender
    {
        Female, Male
    }
}
