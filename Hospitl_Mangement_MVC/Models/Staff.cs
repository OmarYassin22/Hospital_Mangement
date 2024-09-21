namespace Hospitl_Mangement_MVC.Models
{
    public class Staff :BaseEntity
    {
        public string Role { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Departmentid { get; set; }
    }
}
