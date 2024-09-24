using System.ComponentModel.DataAnnotations.Schema;

namespace Hospitl_Mangement_MVC.Models
{
    public class Staff :BaseEntity
    {
        public string? Role { get; set; }
        [ForeignKey("Department")]
        public string? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
