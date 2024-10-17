using Hospitl_Mangement_MVC.Data;
using Hospitl_Mangement_MVC.Models;
using Hospitl_Mangement_MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hospitl_Mangement_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly SignInManager<BaseEntity> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly HospitalDbContext _context;

        public RolesController(SignInManager<BaseEntity> signInManager, RoleManager<IdentityRole> roleManager, HospitalDbContext context)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
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
        public IActionResult AssignRole([Bind("UserId", "RoleId")]UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                _context.UserRoles.Add(new IdentityUserRole<string>
                {
                    RoleId = userRole.RoleId,
                    UserId = userRole.UserId
                });
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(userRole);
        }
    }
}
