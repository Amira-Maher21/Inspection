using Inspection.Domain.Models.Accounting.Payment.CreditNotes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.CreditNotes
{
    public class CreditNoteLineConfiguration : IEntityTypeConfiguration<CreditNoteLine>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<CreditNoteLine> builder)
        {
            builder.ToTable("CreditNoteLine", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.CreditNoteId);

            // Quantities
            builder.Property(x => x.InvoicedQty).HasPrecision(18, 4);
            builder.Property(x => x.PreviousReturnedQty).HasPrecision(18, 4);
            builder.Property(x => x.ReturnedQty).IsRequired().HasPrecision(18, 4);

            // Pricing
            builder.Property(x => x.UnitPrice).IsRequired().HasPrecision(18, 4);
            builder.Property(x => x.TotalPrice).IsRequired().HasPrecision(18, 4);
            builder.Property(x => x.Cost).HasPrecision(18, 6);

            // Discount
            builder.Property(x => x.DiscountValue).HasPrecision(18, 4);
            builder.Property(x => x.DiscountAmount).HasPrecision(18, 4);
            builder.Property(x => x.DiscountType);

            // Tax
            builder.Property(x => x.TaxRate).HasPrecision(5, 2);
            builder.Property(x => x.TaxAmount).HasPrecision(18, 2);
            builder.Property(x => x.IsInclusive).IsRequired();

            // Final Amount
            builder.Property(x => x.NetAmount).IsRequired().HasPrecision(18, 2);

            // Other Properties
            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.Notes).HasMaxLength(500);

            builder.Property(x => x.FreeItem).IsRequired();

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required FKs
            builder.Property(x => x.CreditNoteId).IsRequired();
            builder.Property(x => x.ItemId).IsRequired(false);

            // Optional FKs
            builder.Property(x => x.SalesInvoiceLineId).IsRequired(false);
            builder.Property(x => x.UnitOfMeasureId).IsRequired(false);
            builder.Property(x => x.TaxTypeId).IsRequired(false);
            builder.Property(x => x.WarehouseId).IsRequired(false);
            builder.Property(x => x.WarehouseLocationId).IsRequired(false);

            builder.Property(x => x.CostCenterId).IsRequired(false);
            builder.Property(x => x.CostUnitId).IsRequired(false);
            builder.Property(x => x.OperationId).IsRequired(false);

            // Relationships

            builder.HasOne(x => x.FixedAsset)
                   .WithMany()
                   .HasForeignKey(x => x.AssetId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.WBS)
                   .WithMany()
                   .HasForeignKey(x => x.WBSId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Activity)
                   .WithMany()
                   .HasForeignKey(x => x.ActivityId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.CostCode)
                   .WithMany()
                   .HasForeignKey(x => x.CostCodeId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.SubcontractBOQ)
                   .WithMany()
                   .HasForeignKey(x => x.SubcontractBOQId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ProductionOrder)
                   .WithMany()
                   .HasForeignKey(x => x.ProductionOrderId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.BOQLine)
                   .WithMany()
                   .HasForeignKey(x => x.BOQLineId)
                   .OnDelete(DeleteBehavior.Restrict);


            // Parent
            builder.HasOne(x => x.CreditNote)
                   .WithMany()
                   .HasForeignKey(x => x.CreditNoteId);

            // Sales Invoice Line (Optional)
            builder.HasOne(x => x.SalesInvoiceLine)
                   .WithMany()
                   .HasForeignKey(x => x.SalesInvoiceLineId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Item
            builder.HasOne(x => x.Item)
                   .WithMany()
                   .HasForeignKey(x => x.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            // UOM
            builder.HasOne(x => x.UnitOfMeasure)
                   .WithMany()
                   .HasForeignKey(x => x.UnitOfMeasureId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Tax
            builder.HasOne(x => x.TaxType)
                   .WithMany()
                   .HasForeignKey(x => x.TaxTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Warehouse
            builder.HasOne(x => x.Warehouse)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Location
            builder.HasOne(x => x.Location)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseLocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cost Center
            builder.HasOne(x => x.CostCenter)
                   .WithMany()
                   .HasForeignKey(x => x.CostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cost Unit
            builder.HasOne(x => x.CostUnit)
                   .WithMany()
                   .HasForeignKey(x => x.CostUnitId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Operation
            builder.HasOne(x => x.Operation)
                   .WithMany()
                   .HasForeignKey(x => x.OperationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // CHECK CONSTRAINTS

            // ReturnedQty > 0
            builder.HasCheckConstraint(
                "CK_CreditNoteLine_ReturnedQty",
                "[ReturnedQty] > 0"
            );

            // UnitPrice >= 0
            builder.HasCheckConstraint(
                "CK_CreditNoteLine_UnitPrice",
                "[UnitPrice] >= 0"
            );

            // NetAmount >= 0
            builder.HasCheckConstraint(
                "CK_CreditNoteLine_NetAmount",
                "[NetAmount] >= 0"
            );
        }
    }
}