using Hiring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiring.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees").HasKey(a => a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a => a.name).IsRequired().HasMaxLength(120);
            builder.Property(a => a.email).IsRequired().HasMaxLength(120);
            builder.Property(a => a.password).IsRequired().HasMaxLength(120);
            builder.Property(a => a.phone).IsRequired().HasMaxLength(120);
            builder.Property(a => a.age).IsRequired();
            builder.HasOne(a => a.company).WithMany(a => a.companyEmployees).HasForeignKey(a => a.companyId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.employeeCv).WithOne(a => a.employee).HasForeignKey<CV>(a => a.employeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(a=>a.recommendationsProvided).WithOne(a=>a.recommenderEmployee).HasForeignKey(a=>a.recommenderEmployeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(a=>a.recommendationsReceived).WithOne(a=>a.recommendedEmployee).HasForeignKey(a=>a.recommendedEmployeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(a=>a.appliedVacancies).WithOne(a=>a.employee).HasForeignKey(a=>a.employeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
