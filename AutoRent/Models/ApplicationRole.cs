using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Models
{
    public class ApplicationRole
    {

        public int ApplicationRoleId { get; set; }
        public int AdsNo { get; set; }
        public int PicsNo { get; set; }
        public string RoleImg { get; set; }
        public int OrderNo { get; set; }
        public IdentityRole identityRole { get; set; }
        public double Price { get; set; }
    }
}
