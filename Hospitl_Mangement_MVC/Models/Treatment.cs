using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospitl_Mangement_MVC.Models
{
    public class Treatment
    {
        [Key]
        public int TreatmentId { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientID { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int DoctorID { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentDescription { get; set; }
        public DateTime SartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }

    }
}
