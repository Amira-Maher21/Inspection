using Inspection.Domain.Models.Inventory.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.System.InventoryCostLayers
{
    public class InventoryCostLayerConfiguration : IEntityTypeConfiguration<InventoryCostLayer>
    {
        public void Configure(EntityTypeBuilder<InventoryCostLayer> builder)
        {
            builder.ToTable("InventoryCostLayer", "Inventory");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.QuantityIn).HasPrecision(18, 3).IsRequired();
            builder.Property(x => x.QuantityOut).HasPrecision(18, 3).HasDefaultValue(0).IsRequired();
            builder.Property(x => x.RemainingQty).HasPrecision(18, 3).IsRequired();
            builder.Property(x => x.UnitCost).HasPrecision(18, 6).IsRequired();
            builder.Property(x => x.ReferenceDocumentId).IsRequired();
            builder.Property(x => x.TransactionDate).IsRequired();

            // Relationships

            builder.Property(x => x.QuantityOut)
                   .HasPrecision(18, 3)
                   .HasDefaultValue(0)
                   .IsRequired();

            builder.Property(x => x.RemainingQty)
                   .HasPrecision(18, 3)
                   .IsRequired();

            builder.Property(x => x.UnitCost)
                   .HasPrecision(18, 6)
                   .IsRequired();

            builder.Property(x => x.ReferenceDocumentId)
                   .IsRequired();

            builder.Property(x => x.TransactionDate)
                   .IsRequired();


            //Fk
            // Foreign Keys

            builder.HasOne(x => x.Item)
                   .WithMany()
                   .HasForeignKey(x => x.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Warehouse)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes

            // Unique Layer per transaction (recommended business-safe key)
            builder.HasIndex(x => new
            {
                x.Tenant_ID,
                x.CompanyId,
                x.ItemId,
                x.WarehouseId,
                x.ReferenceDocumentId
            })
            .IsUnique()
            .HasDatabaseName("UQ_InventoryCostLayer_Transaction");

            // For FIFO / cost flow queries
            builder.HasIndex(x => new
            {
                x.Tenant_ID,
                x.ItemId,
                x.WarehouseId,
                x.TransactionDate
            })
            .HasDatabaseName("IX_InventoryCostLayer_FIFO");

            // Constraints

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_CostLayer_QtyIn",
                    "[QuantityIn] >= 0"
                );

                t.HasCheckConstraint(
                    "CK_CostLayer_QtyOut",
                    "[QuantityOut] >= 0"
                );

                t.HasCheckConstraint(
                    "CK_CostLayer_Remaining",
                    "[RemainingQty] >= 0"
                );

                t.HasCheckConstraint(
                    "CK_CostLayer_QtyOut_Less_Than_In",
                    "[QuantityOut] <= [QuantityIn]"
                );

                t.HasCheckConstraint(
                    "CK_CostLayer_Remaining_Valid",
                    "[RemainingQty] = [QuantityIn] - [QuantityOut]"
                );
            });
        }
    }
}