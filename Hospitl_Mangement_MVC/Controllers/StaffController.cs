using Hospitl_Mangement_MVC.Data;
using Hospitl_Mangement_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospitl_Mangement_MVC.Controllers
{
    public class StaffController : Controller
    {
        private readonly HospitalDbContext _context;

        public StaffController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: Staff/CreateNurse
        public IActionResult CreateNurse()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles.Where(x => x.Name != "Doctor" && x.Name != "Patient"), "Id", "Name");
            return View();
        }

        // POST: Staff/CreateNurse
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNurse([Bind("First_Name,Last_Name")] Staff staff)
        {
            if (ModelState.IsValid )
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ViewAll));
            }
            //["RoleId"] = new SelectList(_context.Roles.Where(x => x.Name != "Doctor" && x.Name != "Patient"), "Id", "Name", staff.RoleId);
            return View(staff);
        }
        // POST: Staff/CreateNurse

        // Action to display all staff members
       public IActionResult ViewAll()
        {
            return View(_context.Staff.Include(x=>x.Role).ToList());
        }
    }

}
