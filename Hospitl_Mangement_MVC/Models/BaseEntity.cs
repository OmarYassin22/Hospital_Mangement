namespace Hospitl_Mangement_MVC.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BaseEntity : IdentityUser
    {
        [ MaxLength(35)]
        public string? First_Name { get; set; }

        [ MaxLength(35)]
        public string? Last_Name { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }

}
