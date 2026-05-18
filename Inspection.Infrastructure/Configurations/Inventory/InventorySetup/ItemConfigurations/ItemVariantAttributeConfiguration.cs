using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.InventorySetup.ItemConfigurations
{
    public class ItemVariantAttributeConfiguration : IEntityTypeConfiguration<ItemVariantAttribute>
    {
        public void Configure(EntityTypeBuilder<ItemVariantAttribute> builder)
        {
            builder.ToTable("ItemVariantAttribute", "Inventory");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);

            // UX Constraint
            builder.HasIndex(x => new { x.ItemId, x.AttributeId, x.ItemAttributeValueId })
                   .IsUnique()
                   .HasDatabaseName("UQ_ItemVariantAttribute");

            builder.Property(x => x.ItemId).IsRequired();
            builder.Property(x => x.AttributeId).IsRequired();
            builder.Property(x => x.ItemAttributeValueId).IsRequired();

            // Audit 

            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            builder.HasOne(x => x.Item)
                   .WithMany()
                   .HasForeignKey(x => x.ItemId);
            //.OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ItemAttribute)
                   .WithMany()
                   .HasForeignKey(x => x.AttributeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ItemAttributeValue)
                   .WithMany()
                   .HasForeignKey(x => x.ItemAttributeValueId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}