using Inspection.Domain.Models.Contracting.Setup.Activitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Contracting.Setup.Activitys
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("Activity", "Contracting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID).IsRequired();
            builder.Property(x => x.CompanyId).IsRequired();

            builder.Property(x => x.OperationId).IsRequired();

            builder.Property(x => x.ActivityCode)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.ActivityName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.PlannedCost)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ProgressPercent)
                   .HasColumnType("decimal(5,2)");

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.ActivityCode })
                   .IsUnique();

            // FK → WBS
            builder.HasOne(x => x.WBS)
                   .WithMany()
                   .HasForeignKey(x => x.WBSId)
                   .OnDelete(DeleteBehavior.Restrict);





        }
    }
}