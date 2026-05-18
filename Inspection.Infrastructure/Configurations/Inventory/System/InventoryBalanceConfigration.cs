using Inspection.Domain.Models.Inventory.System.InventoryBalances;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.System
{
    public class InventoryBalanceConfiguration : IEntityTypeConfiguration<InventoryBalance>
    {
        public void Configure(EntityTypeBuilder<InventoryBalance> builder)
        {
            builder.ToTable("InventoryBalance", "Inventory");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.Quantity).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.ReservedQuantity).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.AvailableQuantity)
                   .HasComputedColumnSql("[Quantity] - [ReservedQuantity]", stored: true);
            builder.Property(x => x.AverageCost).HasPrecision(18, 2);

            // Relationships

            builder.HasOne(x => x.Item)
                   .WithMany()
                   .HasForeignKey(x => x.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Warehouse)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.UnitOfMeasure)
                   .WithMany()
                   .HasForeignKey(x => x.BaseUoMId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.WarehouseLocation)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseLocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes

            // Unique per Item + Warehouse + Location + Tenant
            builder.HasIndex(x => new
            { x.Tenant_ID, x.CompanyId, x.ItemId, x.WarehouseId, x.WarehouseLocationId })
                   .IsUnique()
                   .HasDatabaseName("UQ_InventoryBalance_Item_Warehouse_Location");

            // Optional: fast lookup
            builder.HasIndex(x => x.ItemId)
                   .HasDatabaseName("IX_InventoryBalance_Item");

            // Constraints

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_InvBalance_Quantity",
                    "[Quantity] >= 0"
                );

                t.HasCheckConstraint(
                    "CK_InvBalance_ReservedQuantity",
                    "[ReservedQuantity] >= 0"
                );

                t.HasCheckConstraint(
                    "CK_InvBalance_Reserved_Less_Than_Quantity",
                    "[ReservedQuantity] <= [Quantity]"
                );

                t.HasCheckConstraint(
                    "CK_InvBalance_Item_Required",
                    "[ItemId] IS NOT NULL"
                );
            });

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
        }
    }
}