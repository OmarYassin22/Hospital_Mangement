﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospitl_Mangement_MVC.Models
{
    public class Appointment 
    {
        [Key]
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Status { get; set; }
        public string? Reason { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
