using Inspection.Domain.Models.Inspection.Techinal.InspectionStandardApplicabilityRules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inspection.Techinal.InspectionStandardApplicabilityRules
{
    public class InspectionStandardApplicabilityRuleConfiguration
        : IEntityTypeConfiguration<InspectionStandardApplicabilityRule>
    {
        public void Configure(EntityTypeBuilder<InspectionStandardApplicabilityRule> builder)
        {
            builder.ToTable("InspectionStandardApplicabilityRule", "Inspection");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Standard)
                   .WithMany()
                   .HasForeignKey(x => x.StandardId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EquipmentType)
                   .WithMany()
                   .HasForeignKey(x => x.EquipmentTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.InspectionType)
                   .WithMany()
                   .HasForeignKey(x => x.InspectionTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.MinValue)
                   .HasPrecision(18, 4);

            builder.Property(x => x.MaxValue)
                   .HasPrecision(18, 4);

            builder.Property(x => x.Unit)
                   .HasMaxLength(50);

            builder.Property(x => x.IsMandatory)
                   .IsRequired();

            builder.Property(x => x.Disable)
                   .IsRequired()
                   .HasDefaultValue(0);



            // Audit

            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);

            builder.Property(x => x.In_Date).IsRequired();

            builder.Property(x => x.Mod_User).HasMaxLength(100);

            builder.Property(x => x.Mod_Date);
        }
    }
}
