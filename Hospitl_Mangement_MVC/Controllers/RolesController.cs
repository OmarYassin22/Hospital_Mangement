using Hospitl_Mangement_MVC.Data;
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

        public IActionResult Index()
        {

            var users = _userManager.Users;
            var roles = _roleManager.Roles.ToList();
            var userDto =  users.Select(user => new UserViewModel
            {
                FirstName = user.First_Name,
                LastName = user.Last_Name,
                UserName = user.UserName,
                Email = user.Email,
                Roles = _userManager.GetRolesAsync(user).Result
            }).ToListAsync().Result;
            return View(userDto);
        }

        public IActionResult AssignRole()
        {
            var userRole = new UserRole();
            ViewBag.Users = _signInManager.UserManager.Users.ToList();
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View(userRole);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssignRole([Bind("UserId", "RoleId")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                var role = _roleManager.FindByIdAsync(userRole.RoleId).Result;
                var user = _userManager.FindByIdAsync(userRole.UserId).Result;
                _userManager.AddToRoleAsync(user,role.Name);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(userRole);
        }
    }
}
