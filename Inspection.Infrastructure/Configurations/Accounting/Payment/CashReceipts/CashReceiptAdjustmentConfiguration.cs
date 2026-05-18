using Inspection.Domain.Models.Accounting.Payment.CashReceipts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.CashReceipts
{
    public class CashReceiptAdjustmentConfiguration : IEntityTypeConfiguration<CashReceiptAdjustment>
    {
        public void Configure(EntityTypeBuilder<CashReceiptAdjustment> builder)
        {
            builder.ToTable("CashReceiptAdjustment", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => x.CashReceiptId);

            // Properties
            builder.Property(x => x.Amount).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.Description).HasMaxLength(500);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required FKs
            builder.Property(x => x.CashReceiptId).IsRequired();
            builder.Property(x => x.AccountId).IsRequired();

            // Relationships
            // Parent CashReceipt
            builder.HasOne(x => x.CashReceipt)
                   .WithMany()
                   .HasForeignKey(x => x.CashReceiptId);

            // Account
            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.AccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cost Center (Optional)
            builder.HasOne(x => x.CostCenter)
                   .WithMany()
                   .HasForeignKey(x => x.CostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cost Unit (Optional)
            builder.HasOne(x => x.CostUnit)
                   .WithMany()
                   .HasForeignKey(x => x.CostUnitId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Operation (Optional)
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