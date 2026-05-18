using Inspection.Domain.Models.HRManagement.JobTitles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.HRManagement.JobTitles
{
    public class JobTitlesConfig : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder.ToTable("JobTitle", "HR");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Tenant_ID).HasMaxLength(100);

            builder.HasOne(x => x.Department)
                   .WithMany()
                   .HasForeignKey(x => x.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}