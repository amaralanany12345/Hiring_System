using Hiring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiring.Configurations
{
    public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.ToTable("vacancies").HasKey(a=>a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a => a.Title).IsRequired().HasMaxLength(255);
            builder.Property(a => a.Description).IsRequired();
            builder.Property(a => a.yearsOfExperience).IsRequired();
            builder.Property(a => a.Salary).IsRequired();
            builder.Property(a => a.VacancySkills).IsRequired();
            builder.HasOne(a => a.company).WithMany(a => a.companyVacancies).HasForeignKey(a => a.companyId);
            builder.HasMany(a => a.appliedEmployees).WithOne(a => a.vacancy).HasForeignKey(a => a.vacancyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
