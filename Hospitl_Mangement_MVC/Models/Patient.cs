namespace Hospitl_Mangement_MVC.Models
{
    public class Patient : BaseEntity
    {
        public Patient() { }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Emergancy_Contact { get; set; }
        public string Birthdate { get; set; }
        public string Phone { get; set; }

    }
}
