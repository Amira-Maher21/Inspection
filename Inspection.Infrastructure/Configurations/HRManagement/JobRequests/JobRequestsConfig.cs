using Inspection.Domain.Enums;
using Inspection.Domain.Models.HRManagement.JobRequests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.HRManagement.JobRequests
{
    public class JobRequestsConfig : IEntityTypeConfiguration<JobRequest>
    {
        public void Configure(EntityTypeBuilder<JobRequest> builder)
        {
            builder.ToTable("JobRequest", "HR");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.JobDescription).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.NeededPositions).IsRequired();
            builder.Property(x => x.Status).HasDefaultValue(RequestStatus.Pending);
            builder.Property(x => x.RequestedAt).IsRequired();
            builder.Property(x => x.Tenant_ID).HasMaxLength(100);

            builder.HasOne(x => x.Department)
                   .WithMany()
                   .HasForeignKey(x => x.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.JobTitle)
                   .WithMany()
                   .HasForeignKey(x => x.JobTitleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Advertisements)
                   .WithOne(x => x.JobRequest)
                   .HasForeignKey(x => x.JobRequestId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CVs)
                   .WithOne(x => x.JobRequest)
                   .HasForeignKey(x => x.JobRequestId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
