using Inspection.Domain.Models.Inspection.Techinal.AccreditationBodies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inspection.Techinal.AccreditationBodies
{
    public class AccreditationBodyLineConfiguration : IEntityTypeConfiguration<AccreditationBodyLine>
    {
        public void Configure(EntityTypeBuilder<AccreditationBodyLine> builder)
        {
            builder.ToTable("AccreditationBodyLine", "Inspection");

            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => new { x.AccreditationBodyId, x.InspectionTypeId, x.InspectionStandardId }).IsUnique();

            // Properties
            builder.Property(x => x.AccreditationBodyId).IsRequired();
            builder.Property(x => x.InspectionTypeId).IsRequired();
            builder.Property(x => x.InspectionStandardId).IsRequired();

            builder.Property(x => x.RiskLevel).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(1000);

            // Audit 
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Relationships

            // AccreditationBody (Required)
            builder.HasOne(x => x.AccreditationBody)
                   .WithMany()
                   .HasForeignKey(x => x.AccreditationBodyId)
                   .OnDelete(DeleteBehavior.Cascade);

            // InspectionType (Required)
            builder.HasOne(x => x.InspectionType)
                   .WithMany()
                   .HasForeignKey(x => x.InspectionTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // InspectionStandard (Required)
            builder.HasOne(x => x.InspectionStandard)
                   .WithMany()
                   .HasForeignKey(x => x.InspectionStandardId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}