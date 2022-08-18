using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Areas.Company.Controllers
{

    public class Home : Controller
    {
        [Area("Company")]
        [Authorize(Roles = "Company Premium, Company Silver, Company Gold")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
