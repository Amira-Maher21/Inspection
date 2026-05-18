using Inspection.Domain.Models.Inventory.Transaction.InventoryAdjustments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.Transaction.InventoryAdjustments
{
    public class InventoryAdjustmentConfiguration : IEntityTypeConfiguration<InventoryAdjustment>
    {
        public void Configure(EntityTypeBuilder<InventoryAdjustment> builder)
        {
            builder.ToTable("InventoryAdjustment", "Inventory");

            // Primary Key
            builder.HasKey(x => x.Id);

            //  Unique Index (Tenant + Company + Document No)
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.InventoryAdjustmentNumber })
                   .IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.InventoryAdjustmentNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.InventoryAdjustmentDate).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(500);

            // Enums
            builder.Property(x => x.Posting).IsRequired();
            builder.Property(x => x.ApprovalStatus).IsRequired();

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // FKs (Required / Optional)
            builder.Property(x => x.BranchId).IsRequired();
            builder.Property(x => x.WareHouseId).IsRequired(false);

            // Relationships

            // Branch
            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Warehouse (Optional)
            builder.HasOne(x => x.WareHouse)
                   .WithMany()
                   .HasForeignKey(x => x.WareHouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Series
            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Details (Lines)
            builder.HasMany(x => x.InventoryAdjustmentLines)
                   .WithOne(x => x.InventoryAdjustment)
                   .HasForeignKey(x => x.InventoryAdjustmentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}