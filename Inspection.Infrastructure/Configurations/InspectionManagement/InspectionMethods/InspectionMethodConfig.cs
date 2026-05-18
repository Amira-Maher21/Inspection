using Inspection.Domain.Models.InspectionManagement.InspectionMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.InspectionManagement.InspectionMethods
{
    public class InspectionMethodConfig : IEntityTypeConfiguration<InspectionMethod>
    {
        public void Configure(EntityTypeBuilder<InspectionMethod> builder)
        {
            builder.ToTable("InspectionMethod", "Inspection");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Unique Index
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.Code }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(50);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Series
            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}