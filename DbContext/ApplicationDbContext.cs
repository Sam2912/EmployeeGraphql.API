using EmployeeGraphql.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeGraphql.API.DbContext
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .ToTable("Employees")
                .HasDiscriminator(e => e.Type)
                .HasValue<FullTimeEmployee>(EmployeeTypeEnum.FullTime)
                .HasValue<PartTimeEmployee>(EmployeeTypeEnum.PartTime);
        }
    }
}