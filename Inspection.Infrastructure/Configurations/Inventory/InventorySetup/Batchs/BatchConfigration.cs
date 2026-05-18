using Inspection.Domain.Models.Inventory.InventorySetup.Batchs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.InventorySetup.Batchs
{
    public class BatchConfigration : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.ToTable("Batch", "Inventory");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.BatchNumber)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(x => x.CompanyId)
                   .IsRequired();

            builder.Property(x => x.ItemId)
                   .IsRequired();

            builder.Property(x => x.ManufactureDate)
                   .IsRequired(false);

            builder.Property(x => x.ExpiryDate)
                   .IsRequired(false);

            builder.HasIndex(x => new { x.Tenant_ID, x.ItemId, x.BatchNumber })
                  .IsUnique();


            builder.HasOne(x => x.Item)
                   .WithMany()
                   .HasForeignKey(x => x.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Tenant_ID)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(50);

            builder.Property(x => x.Mod_Date)
                   .IsRequired(false);
        }
    }
}