using Hiring.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiring.Configurations
{
    public class RecommendationConfiguration : IEntityTypeConfiguration<Recommendation>
    {
        public void Configure(EntityTypeBuilder<Recommendation> builder)
        {
            builder.ToTable("Recommendations").HasKey(a => a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a => a.description).IsRequired();
            //builder.HasOne(a => a.recommenderEmployee).WithMany(a => a.recommendationsProvided).HasForeignKey(a => a.recommenderEmployeeId).OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(a => a.recommendedEmployee).WithMany(a => a.recommendationsReceived).HasForeignKey(a => a.recommendedEmployeeId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
