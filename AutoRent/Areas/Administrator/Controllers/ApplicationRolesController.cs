using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoRent.Data;
using AutoRent.Models;
using AutoRent.Areas.Administrator.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace AutoRent.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Administrator")]
    public class ApplicationRolesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IWebHostEnvironment _webHostEnvironment;

        public ApplicationRolesController(AppDbContext context, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _roleManager = roleManager;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Administrator/ApplicationRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationRole.Include(r => r.identityRole).ToListAsync());
        }

        // GET: Administrator/ApplicationRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationRole = await _context.ApplicationRole
                .FirstOrDefaultAsync(m => m.ApplicationRoleId == id);
            if (applicationRole == null)
            {
                return NotFound();
            }

            return View(applicationRole);
        }

        // GET: Administrator/ApplicationRoles/Create
        public IActionResult Create()
        {
            return View();
        }
        [AllowAnonymous]
        public string UploadFile(IFormFile roleVmImg)
        {
            string NewFullFileName = null;
            if (roleVmImg != null)
            {
                string FileRoot = Path.Combine(_webHostEnvironment.WebRootPath, @"images\");
                string NewFileName = Guid.NewGuid() + "_" + roleVmImg.FileName;
                string FilePath = Path.Combine(FileRoot, NewFileName);

                using (var myNewFile = new FileStream(FilePath, FileMode.Create))
                {
                    roleVmImg.CopyTo(myNewFile);
                }
                NewFullFileName = @"~/images/" + NewFileName;
                return NewFullFileName;
            }
            return NewFullFileName;
        }
        // POST: Administrator/ApplicationRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRoleViewModel rolevm)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole0 = new IdentityRole
                { 
                    Name = rolevm.RoleName
                };
                var result = await _roleManager.CreateAsync(identityRole0);
                if (result.Succeeded)
                {
                    string RoleImageName = UploadFile(rolevm.RoleImg);
                    ApplicationRole applicationRole = new ApplicationRole
                    {
                        AdsNo = rolevm.AdsNo,
                        OrderNo = rolevm.OrderNo,
                        PicsNo = rolevm.PicsNo,
                        RoleImg = RoleImageName,
                        identityRole = identityRole0, 
                        Price = rolevm.Price
                    };
                    _context.Add(applicationRole);
                    await _context.SaveChangesAsync();
                }
                
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Administrator/ApplicationRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationRole = _context.ApplicationRole.Include(r => r.identityRole).Where(a => a.ApplicationRoleId == id).FirstOrDefault();
            if (applicationRole == null)
            {
                return NotFound();
            }
            //var myNewFile = new FileStream(applicationRole.RoleImg, FileMode.Open);
            EditRoleViewModel rolevm = new EditRoleViewModel
            {
                RoleName = applicationRole.identityRole.Name,
                AdsNo = applicationRole.AdsNo,
                OrderNo = applicationRole.OrderNo,
                PicsNo = applicationRole.PicsNo,
                //RoleImg =  (IFormFile) myNewFile,
                ApplicationRoleId = applicationRole.ApplicationRoleId,
                Price = applicationRole.Price
            };
            return View(rolevm);
        }

        // POST: Administrator/ApplicationRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditRoleViewModel rolevm)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole applicationRole = null;
                if (_context.ApplicationRole.Where(r => r.ApplicationRoleId == id).Any())
                    applicationRole = _context.ApplicationRole.Include(r => r.identityRole).Where(r => r.ApplicationRoleId == id).FirstOrDefault();
                else
                    return NotFound();

                IdentityRole role = await _roleManager.FindByIdAsync(applicationRole.identityRole.Id);
                role.Name = rolevm.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    string RoleImageName = UploadFile(rolevm.RoleImg);
                    applicationRole.AdsNo = rolevm.AdsNo;
                    applicationRole.OrderNo = rolevm.OrderNo;
                    applicationRole.PicsNo = rolevm.PicsNo;
                    applicationRole.RoleImg = RoleImageName;
                    applicationRole.Price = rolevm.Price;

                    try
                    {
                        _context.Update(applicationRole);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ApplicationRoleExists(applicationRole.ApplicationRoleId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rolevm);
        }

        // GET: Administrator/ApplicationRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationRole = await _context.ApplicationRole
                .FirstOrDefaultAsync(m => m.ApplicationRoleId == id);
            if (applicationRole == null)
            {
                return NotFound();
            }

            return View(applicationRole);
        }

        // POST: Administrator/ApplicationRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationRole = await _context.ApplicationRole.FindAsync(id);
            _context.ApplicationRole.Remove(applicationRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationRoleExists(int id)
        {
            return _context.ApplicationRole.Any(e => e.ApplicationRoleId == id);
        }
    }
}
