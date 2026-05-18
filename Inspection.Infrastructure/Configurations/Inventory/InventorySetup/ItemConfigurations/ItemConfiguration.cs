using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.InventorySetup.ItemConfigurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item", "Inventory");

            builder.HasKey(x => x.Id);

            //Indexes & Constraints

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.Code }).IsUnique()
                   .HasDatabaseName("UQ_Item_Company_Code_Tenant");

            builder.HasIndex(x => new { x.CompanyId, x.ItemGroupId })
                   .HasDatabaseName("IX_Item_Company_ItemGroup");

            builder.HasIndex(x => new { x.CompanyId, x.Name })
                   .HasDatabaseName("IX_Item_Company_Name");

            builder.HasIndex(x => x.BarCode).HasDatabaseName("IX_Item_BarCode");

            // Properties

            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.SKU).HasMaxLength(100);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.BarCode).HasMaxLength(100);
            builder.Property(x => x.ItemType).IsRequired();

            builder.Property(x => x.UnitOfMeasureId).IsRequired();

            // Inventory Flags
            builder.Property(x => x.IsStocked).IsRequired();
            builder.Property(x => x.IsSerialTracked).IsRequired();
            builder.Property(x => x.IsBatchTracked).IsRequired();
            builder.Property(x => x.IsExpiryTracked).IsRequired();


            // Stock Control

            builder.Property(x => x.ReorderLevel).HasPrecision(18, 3);
            builder.Property(x => x.ReorderQuantity).HasPrecision(18, 3);
            builder.Property(x => x.SafetyStock).HasPrecision(18, 3);
            builder.Property(x => x.LeadTime);

            // Sales Options
            builder.Property(x => x.Sale).HasDefaultValue(true);
            builder.Property(x => x.IncludeInPOS).HasDefaultValue(false);
            builder.Property(x => x.IncludeInOnline).HasDefaultValue(false);

            // ETA

            builder.Property(x => x.ETAItemType).HasMaxLength(20);
            builder.Property(x => x.ETAItemCode).HasMaxLength(300);

            //Physical Attributes

            builder.Property(x => x.Weight).HasPrecision(18, 3);
            builder.Property(x => x.Volume).HasPrecision(18, 3);
            builder.Property(x => x.Calories).HasPrecision(18, 3);

            // Pricing

            builder.Property(x => x.UnitPrice).HasPrecision(18, 4);
            builder.Property(x => x.UnitCost).HasPrecision(18, 4);

            // Status

            builder.Property(x => x.Disabled).IsRequired().HasDefaultValue(false);

            // Audit 

            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Relationships

            builder.HasMany(x => x.ItemReordersPerWarehouse)
                   .WithOne(x => x.Item)
                   .HasForeignKey(x => x.ItemId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ItemGroup)
                   .WithMany()
                   .HasForeignKey(x => x.ItemGroupId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.UnitOfMeasure)
                   .WithMany()
                   .HasForeignKey(x => x.UnitOfMeasureId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DefaultWarehouse)
                   .WithMany()
                   .HasForeignKey(x => x.DefaultWarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Supplier)
                   .WithMany()
                   .HasForeignKey(x => x.DefaultSupplierId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Document)
                   .WithMany()
                   .HasForeignKey(x => x.ItemPhotoId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Brand)
                   .WithMany()
                   .HasForeignKey(x => x.BrandId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Model)
                   .WithMany()
                   .HasForeignKey(x => x.ModelId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Color)
                   .WithMany()
                   .HasForeignKey(x => x.ColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Size)
                   .WithMany()
                   .HasForeignKey(x => x.SizeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Series)
                  .WithMany()
                  .HasForeignKey(x => x.SeriesId)
                  .OnDelete(DeleteBehavior.Restrict);

            // Self reference (Variant Parent)

            builder.HasOne(x => x.RelatedItemVariant)
                   .WithMany()
                   .HasForeignKey(x => x.RelatedItemVariantId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.VariantAttributes)
                   .WithOne(x => x.Item)
                   .HasForeignKey(x => x.ItemId)
                   .OnDelete(DeleteBehavior.Cascade);


            //  Business Rules (CHECK Constraints) 

            // Inventory item rules
            builder.HasCheckConstraint(
                "CK_Item_Inventory_Rules",
                "([ItemType] <> 1) OR " +
                "([IsStocked] = 1 AND [UnitOfMeasureId] IS NOT NULL)");

            builder.HasCheckConstraint(
                "CK_Item_Service_No_Stock",
                "([ItemType] <> 2) OR " +
                "([IsStocked] = 0 AND [IsSerialTracked] = 0 AND [IsBatchTracked] = 0)");


            //builder.HasCheckConstraint(
            //    "CK_Item_Variant_Rules",
            //    "([HasVariant] = 1 AND [RelatedItemVariantId] IS NULL) OR " +
            //    "([HasVariant] = 0 AND [RelatedItemVariantId] IS NOT NULL) OR " +
            //    "([HasVariant] IS NULL)");

        }
    }
}