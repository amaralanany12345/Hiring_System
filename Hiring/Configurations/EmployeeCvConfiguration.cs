using Hiring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiring.Configurations
{
    public class EmployeeCvConfiguration : IEntityTypeConfiguration<CV>
    {
        public void Configure(EntityTypeBuilder<CV> builder)
        {
            builder.ToTable("CVS").HasKey(a => a.id);
            builder.Property(a=>a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a=>a.fileName).IsRequired();
            builder.Property(a=>a.filePath).IsRequired();
            //builder.HasOne(a=>a.employee).WithOne(a=>a.employeeCv).HasForeignKey<CV>(a=>a.employeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
