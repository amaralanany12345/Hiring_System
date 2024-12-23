using Hiring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiring.Configurations
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("Educations").HasKey(a => a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a => a.StartDate).IsRequired();
            builder.Property(a => a.endDate).IsRequired();
            builder.Property(a => a.educationalInstitute).IsRequired().HasMaxLength(255);
            builder.Property(a => a.description).IsRequired();
            builder.HasOne(a => a.employee).WithMany(a => a.educations).HasForeignKey(a => a.employeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
