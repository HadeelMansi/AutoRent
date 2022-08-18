using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Areas.Administrator.Models.ViewModels
{
    public class EditRoleViewModel
    {
        public int ApplicationRoleId { get; set; }
        public string RoleName { get; set; }
        public int AdsNo { get; set; }
        public int PicsNo { get; set; }
        public IFormFile RoleImg { get; set; }
        public int OrderNo { get; set; }
        public double Price { get; set; }
    }
}
