using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRent.Areas.User.Controllers
{
    public class Home : Controller
    {
        [Area("User")]
        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
