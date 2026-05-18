using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.InventorySetup.ItemConfigurations
{
    public class ItemReorderPerWarehouseConfiguration : IEntityTypeConfiguration<ItemReorderPerWarehouse>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<ItemReorderPerWarehouse> builder)
        {
            builder.ToTable("ItemReorderPerWarehouse", "Inventory");
            builder.HasKey(x => x.Id);

            // Indexes & Constraints

            // Prevent duplicate warehouse reorder settings for the same item
            builder.HasIndex(x => new { x.ItemId, x.DefaultWarehouseId })
                   .IsUnique()
                   .HasDatabaseName("UQ_ItemReorderPerWareHouse_Item_Warehouse");

            // Properties
            builder.Property(x => x.ReorderLevel).IsRequired().HasPrecision(18, 4);
            builder.Property(x => x.ReorderQuantity).IsRequired().HasPrecision(18, 4);
            builder.Property(x => x.SafetyStock).HasPrecision(18, 4);

            // Audit Fields
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Relationships

            // Item (Required)
            builder.HasOne(x => x.Item)
                   .WithMany()
                   .HasForeignKey(x => x.ItemId);

            // Warehouse (Optional)
            builder.HasOne(x => x.DefaultWarehouse)
                   .WithMany()
                   .HasForeignKey(x => x.DefaultWarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Business Rules (CHECK)

            // ReorderLevel must be >= 0
            builder.HasCheckConstraint(
                "CK_ItemReorderPerWareHouse_ReorderLevel_Positive",
                "[ReorderLevel] >= 0");

            // ReorderQuantity must be >= 0
            builder.HasCheckConstraint(
                "CK_ItemReorderPerWareHouse_ReorderQuantity_Positive",
                "[ReorderQuantity] >= 0");

            // SafetyStock must be >= 0 if provided
            builder.HasCheckConstraint(
                "CK_ItemReorderPerWareHouse_SafetyStock_Positive",
                "[SafetyStock] IS NULL OR [SafetyStock] >= 0");
        }
    }
}