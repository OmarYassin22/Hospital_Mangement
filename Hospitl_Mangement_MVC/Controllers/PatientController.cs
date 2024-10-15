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

        [HttpGet]
        public ActionResult MakeAppointment()
        {
            var doctors = _context.Doctor.ToList();

            if (doctors == null || !doctors.Any())
            {
                ViewBag.Doctor = new List<Doctor>();  // تهيئة بقيمة فارغة لتجنب null
            }
            else
            {
                ViewBag.Doctor = doctors;
            }

            return View();
        }

        [HttpPost]
        public ActionResult MakeAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return RedirectToAction("AppointmentConfirmation"); // Redirect after success
            }
            return View(appointment);
        }

        public ActionResult AppointmentConfirmation()
        {
            return View();
        }

    }
}
