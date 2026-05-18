using Inspection.Domain.Models.Inventory.ItemGroups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.ItemGroups
{

    public class ItemGroupConfiguration : IEntityTypeConfiguration<ItemGroup>
    {
        public void Configure(EntityTypeBuilder<ItemGroup> builder)
        {
            builder.ToTable("ItemGroup", "Inventory");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID).IsRequired();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).HasMaxLength(255);

            builder.Property(x => x.CostingMethods).HasMaxLength(20).IsRequired();

            builder.Property(x => x.IsLeaf).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.IsSerialTracking).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.IsBatchTracking).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.IsExpiryTracking).IsRequired().HasDefaultValue(false);

            builder.HasIndex(x => new { x.Tenant_ID, x.Code }).IsUnique();



            builder.HasOne(x => x.PurchaseAccount)
                   .WithMany()
                   .HasForeignKey(x => x.PurchaseAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PurchaseReturnAccount)
                   .WithMany()
                   .HasForeignKey(x => x.PurchaseReturnAccountId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.SalesReturnAccount)
                   .WithMany()
                   .HasForeignKey(x => x.SalesReturnAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.WipAccount)
                   .WithMany()
                   .HasForeignKey(x => x.WipAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.GoodsReceivedNotInvoicedAccount)
                   .WithMany()
                   .HasForeignKey(x => x.GoodsReceivedNotInvoicedAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<ItemGroup>()
                   .WithMany()
                   .HasForeignKey(x => x.ParentGroupId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.InventoryAccount)
                   .WithMany()
                   .HasForeignKey(x => x.InventoryAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CogsAccount)
                   .WithMany()
                   .HasForeignKey(x => x.CogsAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AdjustmentAccount)
                   .WithMany()
                   .HasForeignKey(x => x.AdjustmentAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.RevenueAccount)
                   .WithMany()
                   .HasForeignKey(x => x.RevenueAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}