using Inspection.Domain.Models.Inventory.InventorySetup.ItemAttribute;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.InventorySetup.ItemAttributeConfigurations
{
    public class ItemAttributeConfiguration : IEntityTypeConfiguration<ItemAttribute>
    {
        public void Configure(EntityTypeBuilder<ItemAttribute> builder)
        {
            builder.ToTable("ItemAttribute", "Inventory");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            // UX: Tenant_ID + AttributeName
            builder.HasIndex(x => new { x.Tenant_ID, x.AttributeName })
                   .IsUnique()
                   .HasDatabaseName("UQ_ItemAttribute_Tenant_AttributeName");

            // Properties

            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.AttributeName).IsRequired().HasMaxLength(50);

            // Audit Fields
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Relationships

            builder.HasMany(x => x.ItemAttributeValues)
                   .WithOne(x => x.ItemAttribute)
                   .HasForeignKey(x => x.ItemAttributeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}