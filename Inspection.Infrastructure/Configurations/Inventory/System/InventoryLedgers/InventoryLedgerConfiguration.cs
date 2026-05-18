using Inspection.Domain.Models.Inventory.System.InventoryLedgers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.System.InventoryLedgers
{

    public class InventoryLedgerConfiguration
        : IEntityTypeConfiguration<InventoryLedger>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<InventoryLedger> builder)
        {
            builder.ToTable("InventoryLedger", "Inventory");

            // PK
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            // Dates
            builder.Property(x => x.TransactionDate).IsRequired();
            builder.Property(x => x.PostingDate).IsRequired();

            // Decimal precision
            builder.Property(x => x.QuantityIn).HasPrecision(18, 6);
            builder.Property(x => x.QuantityOut).HasPrecision(18, 6);
            builder.Property(x => x.BalanceAfter).HasPrecision(18, 6).IsRequired();
            builder.Property(x => x.UnitCost).HasPrecision(18, 6);

            // Strings
            builder.Property(x => x.TransactionType).HasMaxLength(50).IsRequired();
            builder.Property(x => x.SourceType).HasMaxLength(50);
            builder.Property(x => x.CostingMethod).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(250);

            builder.Property(x => x.Description)
                   .HasMaxLength(250);




            // Relationships
            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Warehouse)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.WarehouseLocation)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseLocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Item)
                   .WithMany()
                   .HasForeignKey(x => x.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.UnitOfMeasure)
                  .WithMany()
                  .HasForeignKey(x => x.UnitOfMeasureId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Currency)
                .WithMany()
                .HasForeignKey(x => x.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PostingDocumentType)
                    .WithMany()
                    .HasForeignKey(x => x.PostingDocumentTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            builder.HasCheckConstraint(
            "CK_InventoryLedger_QuantityIn_QuantityOut",
            @"(QuantityIn > 0 AND QuantityOut = 0) 
              OR 
              (QuantityIn = 0 AND QuantityOut > 0)");

            builder.HasCheckConstraint(
            "CK_InventoryLedger_QuantityRule",
            @"NOT (QuantityIn > 0 AND QuantityOut > 0)");
        }
    }
}