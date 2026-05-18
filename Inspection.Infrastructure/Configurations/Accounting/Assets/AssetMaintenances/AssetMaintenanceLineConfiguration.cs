using Inspection.Domain.Models.Accounting.Assets.AssetMaintenances;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Assets.AssetMaintenances
{
    public class AssetMaintenanceLineConfiguration : IEntityTypeConfiguration<AssetMaintenanceLine>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<AssetMaintenanceLine> builder)
        {
            builder.ToTable("AssetMaintenanceLine", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => x.AssetMaintenanceId);
            builder.HasIndex(x => x.AssetId);

            // Required Properties
            builder.Property(x => x.AssetMaintenanceId).IsRequired();
            builder.Property(x => x.AssetId).IsRequired();
            builder.Property(x => x.WorkDescription).IsRequired().HasMaxLength(500);
            builder.Property(x => x.MaintenanceActionType).IsRequired();
            builder.Property(x => x.IsCapitalizable).IsRequired();

            // Optional numeric fields
            builder.Property(x => x.DowntimeHours).HasPrecision(18, 2);
            builder.Property(x => x.EstimatedCost).HasPrecision(18, 2);
            builder.Property(x => x.ActualCost).HasPrecision(18, 2);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Relationships

            // Parent
            builder.HasOne(x => x.AssetMaintenance)
                   .WithMany()
                   .HasForeignKey(x => x.AssetMaintenanceId);

            // Asset
            builder.HasOne(x => x.Asset)
                   .WithMany()
                   .HasForeignKey(x => x.AssetId)
                   .OnDelete(DeleteBehavior.Restrict);

            // WBS
            builder.HasOne(x => x.WBS)
                   .WithMany()
                   .HasForeignKey(x => x.WBSId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Activity
            builder.HasOne(x => x.Activity)
                   .WithMany()
                   .HasForeignKey(x => x.ActivityId)
                   .OnDelete(DeleteBehavior.Restrict);

            // BOQ
            builder.HasOne(x => x.BOQ)
                   .WithMany()
                   .HasForeignKey(x => x.BOQItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Subcontract BOQ
            builder.HasOne(x => x.SubcontractBOQ)
                   .WithMany()
                   .HasForeignKey(x => x.SubcontractBOQId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Production Order
            builder.HasOne(x => x.ProductionOrder)
                   .WithMany()
                   .HasForeignKey(x => x.ProductionOrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cost Code
            builder.HasOne(x => x.CostCode)
                   .WithMany()
                   .HasForeignKey(x => x.CostCodeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Operation
            builder.HasOne(x => x.Operation)
                   .WithMany()
                   .HasForeignKey(x => x.OperationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cost Center
            builder.HasOne(x => x.CostCenter)
                   .WithMany()
                   .HasForeignKey(x => x.CostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            // CHECK CONSTRAINTS

            builder.HasCheckConstraint(
                "CK_AssetMaintenanceLine_DowntimeHours",
                "[DowntimeHours] IS NULL OR [DowntimeHours] >= 0"
            );

            builder.HasCheckConstraint(
                "CK_AssetMaintenanceLine_EstimatedCost",
                "[EstimatedCost] IS NULL OR [EstimatedCost] >= 0"
            );

            builder.HasCheckConstraint(
                "CK_AssetMaintenanceLine_ActualCost",
                "[ActualCost] IS NULL OR [ActualCost] >= 0"
            );
        }
    }
}