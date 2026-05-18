using Inspection.Domain.Models.Inventory.InventorySetup.ItemAttribute;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.InventorySetup.ItemAttributeConfigurations
{
    public class ItemAttributeValueConfiguration : IEntityTypeConfiguration<ItemAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ItemAttributeValue> builder)
        {
            builder.ToTable("ItemAttributeValue", "Inventory");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Unique Constraint
            // UX: AttributeId + AttributeValue
            builder.HasIndex(x => new { x.ItemAttributeId, x.AttributeValue })
                   .IsUnique()
                   .HasDatabaseName("UQ_ItemAttributeValue_AttributeId_Value");

            // Properties

            builder.Property(x => x.ItemAttributeId).IsRequired();
            builder.Property(x => x.AttributeValue).IsRequired().HasMaxLength(50);

            // Audit Fields
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Relationship

            builder.HasOne(x => x.ItemAttribute)
                   .WithMany()
                   .HasForeignKey(x => x.ItemAttributeId);
        }
    }
}