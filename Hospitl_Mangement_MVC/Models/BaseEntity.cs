namespace Hospitl_Mangement_MVC.Models
{
    using System;

    public abstract class BaseEntity
    {
        // Primary Key
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
