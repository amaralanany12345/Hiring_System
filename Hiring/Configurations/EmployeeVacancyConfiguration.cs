using Hiring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiring.Configurations
{
    public class EmployeeVacancyConfiguration : IEntityTypeConfiguration<EmployeeVacancies>
    {
        public void Configure(EntityTypeBuilder<EmployeeVacancies> builder)
        {
            builder.ToTable("EmployeeVacancies").HasKey(a => new { a.vacancyId, a.employeeId });
            builder.Property(a => a.vacancyState).IsRequired();
            builder.HasOne(a=>a.vacancy).WithMany(a=>a.appliedEmployees).HasForeignKey(a=>a.vacancyId);
            builder.HasOne(a=>a.employee).WithMany(a=>a.appliedVacancies).HasForeignKey(a=>a.employeeId);
        }
    }
}
