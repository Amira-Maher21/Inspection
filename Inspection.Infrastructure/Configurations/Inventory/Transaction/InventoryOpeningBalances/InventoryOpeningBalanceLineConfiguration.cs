using Inspection.Domain.Models.Inventory.Transaction.InventoryOpeningsBalance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.Transaction.InventoryOpeningBalances
{
    public class InventoryOpeningBalanceLineConfiguration : IEntityTypeConfiguration<InventoryOpeningBalanceLine>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<InventoryOpeningBalanceLine> builder)
        {
            builder.ToTable("InventoryOpeningBalanceLine", "Inventory");

            // Primary Key
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.InventoryOpeningBalanceId);

            // Unique Index
            builder.HasIndex(x => new
            {
                x.InventoryOpeningBalanceId,
                x.ItemId,
                x.WarehouseLocationId
            }).IsUnique();

            // Quantities & Cost
            builder.Property(x => x.Quantity).IsRequired().HasPrecision(18, 6);
            builder.Property(x => x.UnitCost).IsRequired().HasPrecision(18, 6);
            builder.Property(x => x.TotalCost).IsRequired().HasPrecision(18, 6);

            // Tracking Fields
            builder.Property(x => x.SerialNumber).HasMaxLength(100);
            builder.Property(x => x.Notes).HasMaxLength(250);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required FKs
            builder.Property(x => x.InventoryOpeningBalanceId).IsRequired();
            builder.Property(x => x.ItemId).IsRequired();

            // Optional FKs
            builder.Property(x => x.WarehouseLocationId).IsRequired(false);
            builder.Property(x => x.BatchId).IsRequired(false);

            builder.Property(x => x.CostCenterId).IsRequired(false);
            builder.Property(x => x.CostUnitId).IsRequired(false);
            builder.Property(x => x.OperationId).IsRequired(false);

            // Relationships

            // Parent
            builder.HasOne(x => x.InventoryOpeningBalance)
                   .WithMany(x => x.InventoryOpeningBalanceLines)
                   .HasForeignKey(x => x.InventoryOpeningBalanceId);

            // Item
            builder.HasOne(x => x.Item)
                   .WithMany()
                   .HasForeignKey(x => x.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Location
            builder.HasOne(x => x.WarehouseLocation)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseLocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Batch
            builder.HasOne(x => x.Batch)
                   .WithMany()
                   .HasForeignKey(x => x.BatchId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cost Center
            builder.HasOne(x => x.CostCenter)
                   .WithMany()
                   .HasForeignKey(x => x.CostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cost Unit
            builder.HasOne(x => x.CostUnit)
                   .WithMany()
                   .HasForeignKey(x => x.CostUnitId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Operation
            builder.HasOne(x => x.Operation)
                   .WithMany()
                   .HasForeignKey(x => x.OperationId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.WBS)
                   .WithMany()
                   .HasForeignKey(x => x.WBSId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Activity)
                   .WithMany()
                   .HasForeignKey(x => x.ActivityId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.CostCode)
                   .WithMany()
                   .HasForeignKey(x => x.CostCodeId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.SubcontractBOQ)
                   .WithMany()
                   .HasForeignKey(x => x.SubcontractBOQId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ProductionOrder)
                   .WithMany()
                   .HasForeignKey(x => x.ProductionOrderId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.BOQLine)
                   .WithMany()
                   .HasForeignKey(x => x.BOQLineId)
                   .OnDelete(DeleteBehavior.Restrict);



            //  Check Constraint
            // Serial → Quantity = 1
            builder.HasCheckConstraint(
                "CK_InventoryOpeningBalanceLine_SerialQty",
                "[SerialNumber] IS NULL OR [Quantity] = 1"
            );
        }
    }
}