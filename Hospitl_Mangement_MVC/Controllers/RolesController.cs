﻿using Hospitl_Mangement_MVC.Data;
using Hospitl_Mangement_MVC.Models;
using Hospitl_Mangement_MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospitl_Mangement_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly SignInManager<BaseEntity> _signInManager;
        private readonly UserManager<BaseEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly HospitalDbContext _context;

        public RolesController(SignInManager<BaseEntity> signInManager, RoleManager<IdentityRole> roleManager, HospitalDbContext context, UserManager<BaseEntity> userManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Get all users
            var users = await _userManager.Users.Select(user => new UserViewModel
            {
                FirstName = user.First_Name,
                LastName = user.Last_Name,
                UserName = user.UserName,
                Email = user.Email
            }).ToListAsync();

            // Fetch roles for each user asynchronously
            foreach (var user in users)
            {
                var appUser = await _userManager.FindByNameAsync(user.UserName);
                user.Roles = await _userManager.GetRolesAsync(appUser);
            }

            return View(users);
        }
        [HttpGet("AssignRole/{email}")]
        public IActionResult AssignRole(string email)
        {
            var userRole = new UserRole()
            {
                email = email
            };
            ViewBag.Users = email;
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View(userRole);
        }
        [HttpPost("AssignRole/{email}")]
        [ValidateAntiForgeryToken]
        public IActionResult AssignRole( UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                var role = _roleManager.FindByIdAsync(userRole.RoleId).Result;
                var user = _userManager.FindByEmailAsync(userRole.email).Result;
                foreach (var r in _roleManager.Roles)
                {

                    var temp = _userManager.RemoveFromRoleAsync(user, r.Name).Result;
                }
                    var result = _userManager.AddToRoleAsync(user, role.Name).Result;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(userRole);
        }
    }
}
