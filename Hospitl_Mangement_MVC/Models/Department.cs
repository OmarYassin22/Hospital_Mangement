using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospitl_Mangement_MVC.Models
{
    public class Department 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? DepartmentName { get; set; }
        [Required, MaxLength(100)]
        public string? Location { get; set; }
        //[ForeignKey("Staff")]
        public int StaffId { get; set; }
        public ICollection<Staff>? Staff { get; set; }
        //[ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public ICollection<Doctor>? Doctor { get; set; }

    }
}
