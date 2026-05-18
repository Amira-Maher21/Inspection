using Inspection.Domain.Models.Accounting.Assets.AssetMaintenances;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Assets.AssetMaintenances
{
    public class AssetMaintenanceConfiguration : IEntityTypeConfiguration<AssetMaintenance>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<AssetMaintenance> builder)
        {
            builder.ToTable("AssetMaintenance", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.BranchId, x.MaintenanceCode }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.MaintenanceCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MaintenanceType).IsRequired();
            builder.Property(x => x.FrequencyValue);
            builder.Property(x => x.MaintenanceDate).IsRequired();
            builder.Property(x => x.PlannedStartDate);
            builder.Property(x => x.PlannedEndDate);
            builder.Property(x => x.Technician).HasMaxLength(150);
            builder.Property(x => x.TotalEstimatedCost).HasPrecision(18, 2);
            builder.Property(x => x.TotalActualCost).HasPrecision(18, 2);
            builder.Property(x => x.InspectionRequired).IsRequired();
            builder.Property(x => x.CertificateNumber).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.DocumentStatus).IsRequired();
            builder.Property(x => x.IsApproved).IsRequired();

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required Relationships
            builder.Property(x => x.BranchId).IsRequired();

            // Supplier (optional)
            builder.Property(x => x.SupplierId);

            // Relations

            // Branch
            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Supplier
            builder.HasOne(x => x.Supplier)
                   .WithMany()
                   .HasForeignKey(x => x.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Lines
            builder.HasMany(x => x.AssetMaintenanceLines)
                   .WithOne(x => x.AssetMaintenance)
                   .HasForeignKey(x => x.AssetMaintenanceId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Series
            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);

            // CHECK CONSTRAINTS

            // Maintenance Type
            builder.HasCheckConstraint(
                "CK_AssetMaintenance_MaintenanceType",
                "[MaintenanceType] IN (1,2,3,4,5)"
            );

            // Document Status (1 Planned, 2 Completed)
            builder.HasCheckConstraint(
                "CK_AssetMaintenance_DocumentStatus",
                "[DocumentStatus] IN (1,2)"
            );

            // Frequency Value must be positive if exists
            builder.HasCheckConstraint(
                "CK_AssetMaintenance_FrequencyValue",
                "[FrequencyValue] IS NULL OR [FrequencyValue] > 0"
            );

            // Cost validation
            builder.HasCheckConstraint(
                "CK_AssetMaintenance_Costs",
                "[TotalEstimatedCost] IS NULL OR [TotalEstimatedCost] >= 0 AND " +
                "[TotalActualCost] IS NULL OR [TotalActualCost] >= 0"
            );
        }
    }
}