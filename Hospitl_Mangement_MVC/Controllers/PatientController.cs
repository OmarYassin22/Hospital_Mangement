using Hospitl_Mangement_MVC.Data;
using Hospitl_Mangement_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospitl_Mangement_MVC.Controllers
{
    public class PatientController : Controller
    {
        private readonly HospitalDbContext _context;

        public PatientController(HospitalDbContext context)
        {
            _context = context;
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
        public ActionResult Submit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                _context.SaveChanges();

                // Redirect or show success message
                ViewBag.Message = "Your appointment request has been sent successfully.";
                return RedirectToAction();
            }

            // If invalid, reload the form with errors and available doctors
            ViewBag.Doctor = _context.Doctor.ToList();
            return View();
        }

        private List<Doctor> GetDoctors()
        {
            // Simulated list of doctors, replace with actual database call
            return new List<Doctor>
            {

            };
        }
        // GET: Prescription/SeePrescription
      

        public ActionResult AppointmentConfirmation()
        {
            return View();
        }

    }
}
