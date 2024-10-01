using Hospitl_Mangement_MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospitl_Mangement_MVC.Data
{
    public class HospitalDbContext :  IdentityDbContext<BaseEntity>
    {
        public HospitalDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Patient>().ToTable("Patients");

        }
        // baseentity
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
