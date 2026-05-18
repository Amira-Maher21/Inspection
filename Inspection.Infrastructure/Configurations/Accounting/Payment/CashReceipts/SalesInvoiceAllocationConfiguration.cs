using Inspection.Domain.Models.Accounting.Payment.CashReceipts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.CashReceipts
{
    public class SalesInvoiceAllocationConfiguration : IEntityTypeConfiguration<SalesInvoiceAllocation>
    {
        public void Configure(EntityTypeBuilder<SalesInvoiceAllocation> builder)
        {
            builder.ToTable("SalesInvoiceAllocation", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Amount).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.Description).HasMaxLength(500);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required FKs
            builder.Property(x => x.SalesInvoiceId).IsRequired();
            builder.Property(x => x.CashReceiptId).IsRequired();

            // Indexes
            builder.HasIndex(x => x.SalesInvoiceId);
            builder.HasIndex(x => x.CashReceiptId);

            //// Check Constraint
            //builder.HasCheckConstraint(
            //    "CK_InvoiceAllocation_OneMaster",
            //    @"(CashReceiptId IS NOT NULL)"
            //// لو هتضيف ChequeReceipt مستقبلاً:
            //// @"(CashReceiptId IS NOT NULL AND ChequeReceiptId IS NULL) OR
            ////   (CashReceiptId IS NULL AND ChequeReceiptId IS NOT NULL)"
            //);

            // Relationships

            // SalesInvoice (Required)
            builder.HasOne(x => x.SalesInvoice)
                   .WithMany()
                   .HasForeignKey(x => x.SalesInvoiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            // SalesInvoiceLine (Optional)
            builder.HasOne(x => x.SalesInvoiceLine)
                   .WithMany()
                   .HasForeignKey(x => x.SalesInvoiceLineId)
                   .OnDelete(DeleteBehavior.Restrict);

            // CashReceipt (Parent)
            builder.HasOne(x => x.CashReceipt)
                   .WithMany()
                   .HasForeignKey(x => x.CashReceiptId);

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

        }
    }
}