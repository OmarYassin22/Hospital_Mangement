namespace Hospitl_Mangement_MVC.Models
{
    public class Doctor :BaseEntity
    {
        public string Speciatly { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Departmentid { get; set; }
    }
}
