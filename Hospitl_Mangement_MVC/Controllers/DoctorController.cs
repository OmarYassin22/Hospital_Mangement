using Hospitl_Mangement_MVC.Data;
using Hospitl_Mangement_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospitl_Mangement_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DoctorController : Controller
    {
        private readonly HospitalDbContext _context;

        public DoctorController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: Doctor/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName");
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Speciatly,DepartmentId,First_Name,Last_Name")] Doctor doctor)
        {
           if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Viewall));
            }
            else
            {
                // Collect missing or invalid data fields
                var errorMessages = ModelState.Where(ms => ms.Value.Errors.Count > 0)
                                              .Select(ms => ms.Key) // Get the field names
                                              .ToList();

                // Create a message for the missing or invalid fields
                string missingDataMessage = "The following fields have errors or missing data: " + string.Join(", ", errorMessages);

                // Add the message to the ModelState, so it can be displayed
                ModelState.AddModelError(string.Empty, missingDataMessage);

                // Re-populate the Department dropdown in case of validation errors
                ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName", doctor.DepartmentId);

                // Return the view with validation errors and input data
                return View(doctor);
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName", doctor.DepartmentId);
            return RedirectToAction(nameof(Viewall));
            //return View(doctor);

        }
        public IActionResult Viewall()
        {
            return View(_context.Doctor.Include(x=>x.Department).ToList());
        }
    }

}
