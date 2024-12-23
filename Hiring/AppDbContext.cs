using Hiring.Models;
using Microsoft.EntityFrameworkCore;

namespace Hiring
{
    public class AppDbContext:DbContext
    {
        public DbSet<Company> companies { get; set; }    
        public DbSet<Employee> employees { get; set; }
        public DbSet<Experience> experiences { get; set; }
        public DbSet<Recommendation> recommendations { get; set; }
        public DbSet<Education> educations { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<Vacancy> vacancies { get; set; }
        public DbSet<CV> CVS { get; set; }
        public DbSet<EmployeeVacancies> employeeVacancies{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-NNDJ4G3D\SQLEXPRESS; Database =Hiring; Integrated Security =SSPI; TrustServerCertificate =True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
