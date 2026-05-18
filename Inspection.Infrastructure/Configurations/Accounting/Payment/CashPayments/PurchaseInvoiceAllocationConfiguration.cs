using Inspection.Domain.Models.Accounting.Payment.CashPayments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.CashPayments
{
    public class PurchaseInvoiceAllocationConfiguration : IEntityTypeConfiguration<PurchaseInvoiceAllocation>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoiceAllocation> builder)
        {
            builder.ToTable("PurchaseInvoiceAllocation", "Accounting");

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
            builder.Property(x => x.PurchaseInvoiceId).IsRequired();
            builder.Property(x => x.CashPaymentId).IsRequired();

            // Indexes
            builder.HasIndex(x => x.PurchaseInvoiceId);
            builder.HasIndex(x => x.CashPaymentId);

            // Relationships

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





            // PurchaseInvoice (Required)
            builder.HasOne(x => x.PurchaseInvoice)
                   .WithMany()
                   .HasForeignKey(x => x.PurchaseInvoiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            // PurchaseInvoiceLine (Optional)
            builder.HasOne(x => x.PurchaseInvoiceLine)
                   .WithMany()
                   .HasForeignKey(x => x.PurchaseInvoiceLineId)
                   .OnDelete(DeleteBehavior.Restrict);

            // CashPayment (Parent)
            builder.HasOne(x => x.CashPayment)
                   .WithMany()
                   .HasForeignKey(x => x.CashPaymentId);

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
        }
    }
}