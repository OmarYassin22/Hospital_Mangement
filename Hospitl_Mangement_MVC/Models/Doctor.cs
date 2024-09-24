using System.ComponentModel.DataAnnotations.Schema;

namespace Hospitl_Mangement_MVC.Models
{
    public class Doctor :BaseEntity
    {
        public string? Speciatly { get; set; }
        public string? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public string? AppointmentId { get; set; }
        public ICollection<Appointment>? Appointment { get; set; }
    }
}
