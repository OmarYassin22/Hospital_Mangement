using Hospitl_Mangement_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospitl_Mangement_MVC.Data
{
    public class HospitalDbContext :DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
