using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Areas.Administrator.Models.ViewModels
{
    public class EditUserViewModel
    {
        public string UserId{ get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
