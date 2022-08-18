using AutoRent.Models;
using AutoRent.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoRent.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoRent.Controllers
{


    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;

        #region User
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register(string Id)
        {
            ViewBag.RolName = Id;
            return View();
        }
        public string UploadFile(RegViewModel regVm)
        {
            string NewFullFileName = null;
            if (regVm.IDImage != null)
            {
                string FileRoot = Path.Combine(_webHostEnvironment.WebRootPath, @"images\");
                string NewFileName = Guid.NewGuid() + "_" + regVm.IDImage.FileName;
                string FilePath = Path.Combine(FileRoot, NewFileName);

                using (var myNewFile = new FileStream(FilePath, FileMode.Create))
                {
                    regVm.IDImage.CopyTo(myNewFile);

                }
                NewFullFileName = @"~/images/" + NewFileName;
                return NewFullFileName;
            }
            return NewFullFileName;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(string RolName, RegViewModel UserVm )
        {
            if (ModelState.IsValid)
            {
                string IDImageName = UploadFile(UserVm);
                
                ApplicationUser user = new ApplicationUser
                {
                    Email = UserVm.Email,
                    PhoneNumber = UserVm.Mobile,
                    UserName = UserVm.UserName,
                    Address = UserVm.Address,
                    IDImage = IDImageName,
                    Gender = UserVm.Gender,
                    LockoutEnd = DateTime.Now.AddYears(100)
                };
                var result = await _userManager.CreateAsync(user, UserVm.Password);
                if (result.Succeeded)
                {
                    //await _signInManager.SignInAsync(user, false);
                    ViewData["RegMsg"] = "Registration Done Successfully. Please Wait While The Admin Activate Your Registration";
                    string RoleName =  _roleManager.Roles.Where(r => r.Id == RolName).FirstOrDefault().Name;
                    var result2 = await _userManager.AddToRoleAsync(user, RoleName);
                    foreach (var err in result2.Errors)
                    {
                        ModelState.AddModelError(string.Empty, err.Description);
                    }
                    //return RedirectToAction("index", "Home");
                }

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Register0()
        {
            return View(await _context.ApplicationRole.Include(r => r.identityRole).ToListAsync());
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel logVm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(logVm.UserName, logVm.Password, logVm.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    
                    ApplicationUser user = _context.Users.Where(u => u.UserName == logVm.UserName).FirstOrDefault();
                    List<string> Roles =  _userManager.GetRolesAsync(user).Result.ToList();
                    
                    for (int i = 0; i < Roles.Count; i++)
                    {
                        
                        if (Roles[i].Contains("Admin"))
                            return RedirectToAction("Index", "Home", new { area = "Administrator" });
                        if (Roles[i].Contains("Company"))
                            return RedirectToAction("Index", "Home", new { area = "Company" });
                        if (Roles[i].Contains("User"))
                            return RedirectToAction("Index", "Home", new { area = "User" });
                    }
                }
                if (result.IsLockedOut)
                    ModelState.AddModelError("", "The User Is Not Active! Please Review Your Administrator!");
                else
                {
                    if (_userManager.Users.Where(x => x.UserName == logVm.UserName).Any())
                        ModelState.AddModelError("", "Invalid User Name/ Password");
                    else
                        ModelState.AddModelError("", "The User Is Not Exists, Please Register or Check You User Name");
                }
            }
            return View(logVm);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel roleVm)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = roleVm.RoleName
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {

                    return RedirectToAction("AllRoles");
                }

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
                return View(roleVm);
            }
            return View(roleVm);
        }

        public IActionResult AllRoles()
        {
            return View(_roleManager.Roles.ToList());
        }

        

    }
}
