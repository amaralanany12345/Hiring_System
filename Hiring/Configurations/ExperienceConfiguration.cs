using Hiring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiring.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.ToTable("Experiences").HasKey(a => a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a => a.StartDate).IsRequired();
            builder.Property(a => a.endDate).IsRequired();
            builder.Property(a => a.companyName).IsRequired();
            builder.Property(a => a.description).IsRequired();
            builder.HasOne(a => a.employee).WithMany(a => a.experiences).HasForeignKey(a => a.employeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
