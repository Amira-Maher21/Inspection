using Inspection.Domain.Enums;
using Inspection.Domain.Models.EquipmentManagement.EquipmentInspections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.EquipmentManagement.EquipmentInspections
{
    public class EquipmentInspectionConfig : IEntityTypeConfiguration<EquipmentInspection>
    {
        public void Configure(EntityTypeBuilder<EquipmentInspection> builder)
        {
            builder.ToTable("EquipmentInspection", "Inspection");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ConditionNotes).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.IsOperational).IsRequired();
            builder.Property(x => x.InspectedAt).IsRequired();
            builder.Property(x => x.Result).IsRequired().HasDefaultValue(InspectionResult.Pending);
            builder.Property(x => x.Tenant_ID).HasMaxLength(100);

            //builder.HasOne(x => x.Equipment)
            //       .WithMany(e => e.Inspections)
            //       .HasForeignKey(x => x.EquipmentId)
            //       .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(x => x.InspectionOrder)
            //       .WithMany()
            //       .HasForeignKey(x => x.InspectionOrderId)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}