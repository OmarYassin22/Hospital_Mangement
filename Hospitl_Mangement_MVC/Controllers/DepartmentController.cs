using Hospitl_Mangement_MVC.Data;
using Hospitl_Mangement_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospitl_Mangement_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private readonly HospitalDbContext _context;

        public DepartmentController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: Doctor/Create edit it 
        public IActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_context.Department, "Id", "DepartmentName");
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentName,Location")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ViewAll));
            }
            return View();
        }
        public async Task<IActionResult> ViewAll()
        {
            return View(_context.Department.ToList());
        }
    }
}
