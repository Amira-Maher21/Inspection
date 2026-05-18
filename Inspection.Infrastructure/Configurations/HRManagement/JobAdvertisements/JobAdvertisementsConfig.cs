using Inspection.Domain.Models.HRManagement.JobAdvertisements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.HRManagement.JobAdvertisements
{
    public class JobAdvertisementsConfig : IEntityTypeConfiguration<JobAdvertisement>
    {
        public void Configure(EntityTypeBuilder<JobAdvertisement> builder)
        {
            builder.ToTable("JobAdvertisement", "HR");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Platform).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Url).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PostedAt).IsRequired();
            builder.Property(x => x.Tenant_ID).HasMaxLength(100);

            builder.HasOne(x => x.JobRequest)
                   .WithMany(x => x.Advertisements)
                   .HasForeignKey(x => x.JobRequestId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}