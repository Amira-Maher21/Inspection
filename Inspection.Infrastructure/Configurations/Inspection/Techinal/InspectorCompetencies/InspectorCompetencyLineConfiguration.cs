using Inspection.Domain.Models.Inspection.Techinal.InspectorCompetencies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inspection.Techinal.InspectorCompetencies
{
    public class InspectorCompetencyLineConfiguration : IEntityTypeConfiguration<InspectorCompetencyLine>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<InspectorCompetencyLine> builder)
        {
            builder.ToTable("InspectorCompetencyLine", "Inspection");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Foreign Keys
            builder.Property(x => x.InspectorCompetencyId).IsRequired();

            builder.HasOne(x => x.InspectorCompetency)
                   .WithMany()
                   .HasForeignKey(x => x.InspectorCompetencyId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Inspection Method (Required)
            builder.Property(x => x.InspectionMethodId).IsRequired();

            builder.HasOne(x => x.InspectionMethod)
                   .WithMany()
                   .HasForeignKey(x => x.InspectionMethodId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Inspection Type (Optional)
            builder.HasOne(x => x.InspectionType)
                   .WithMany()
                   .HasForeignKey(x => x.InspectionTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Properties
            builder.Property(x => x.MaxLevel).IsRequired().HasMaxLength(20);
            builder.Property(x => x.CertificationNo).HasMaxLength(50);
            builder.Property(x => x.CertificationExpiry).HasColumnType("date");
            builder.Property(x => x.Disabled).IsRequired().HasDefaultValue(false);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);


            // Indexes (Performance)
            builder.HasIndex(x => new { x.InspectorCompetencyId, x.InspectionMethodId, x.InspectionTypeId });

            // Optional Check Constraints

            builder.HasCheckConstraint(
                "CK_InspectorCompetencyLine_CertificationExpiry",
                "[CertificationExpiry] IS NULL OR [CertificationExpiry] >= [In_Date]");
        }
    }
}