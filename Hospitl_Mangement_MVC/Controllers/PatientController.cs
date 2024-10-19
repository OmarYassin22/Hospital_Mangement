
using Hospitl_Mangement_MVC.Data;
using Hospitl_Mangement_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace Hospitl_Mangement_MVC.Controllers
{
    [Authorize(Roles = "Patient")]
    public class PatientController : Controller
    {
        private readonly HospitalDbContext _context;
        private readonly UserManager<BaseEntity>_userManager ;


        public IActionResult Index()
        {
            return View();
        }
        public PatientController(HospitalDbContext context, UserManager<BaseEntity> userManager)
        {
            _context = context;
            _userManager = userManager; 
        }

        // GET: Appointment
        public ActionResult MakeAppointment()
        {
            // Simulate fetching available doctors from database or service
            ViewBag.Doctor = _context.Doctor.ToList();

            return View();
        }

        // POST: Appointment/Submit
        [HttpPost]
        public async Task <IActionResult> Submit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
<<<<<<< HEAD

=======
                //var user= await _userManager.GetUserAsync(User);
                //appointment.PatientId = user?.Id;
>>>>>>> ec0629009a2b9e2d80efe2095b7a501b75c838ff
                _context.Add(appointment);
                _context.SaveChanges();

                // Store success message in TempData to display after redirection
                TempData["SuccessMessage"] = "Your appointment request has been sent successfully.";
                return RedirectToAction("MakeAppointment");
            }

            // If invalid, reload the form with errors and available doctors
            ViewBag.Doctor = _context.Doctor.ToList();
            return View("MakeAppointment");
        }


        private List<Doctor> GetDoctors()
        {
            // Simulated list of doctors, replace with actual database call
            return new List<Doctor>
            {

            };
        }

        public ActionResult AppointmentConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewPrescription(int prescriptionId)
        {
            // Fetch the prescription with the related treatment and medication details
            var prescription = _context.Prescriptions
                                       .Include(p => p.Medications) // Include the related medications
                                       .FirstOrDefault(p => p.PrescriptionID == prescriptionId);

            // Check if the prescription exists
            if (prescription == null)
            {
                return NotFound("Prescription not found.");
            }

            // Pass the prescription data to the view
            return View(ViewPrescription);
        }

    }
}
