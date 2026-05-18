using Inspection.Domain.Models.Accounting.Payment.CashPayments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.CashPayments
{
    public class CashPaymentLineConfiguration : IEntityTypeConfiguration<CashPaymentLine>
    {
        public void Configure(EntityTypeBuilder<CashPaymentLine> builder)
        {
            builder.ToTable("CashPaymentLine", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.CashPaymentId);

            // Properties
            builder.Property(x => x.Amount).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.FeesAmount).HasPrecision(18, 2);
            builder.Property(x => x.ReferenceNumber).HasMaxLength(100);
            builder.Property(x => x.Notes).HasMaxLength(500);
            builder.Property(x => x.ChequeNumber).HasMaxLength(100);
            builder.Property(x => x.ReferenceDate);
            builder.Property(x => x.ChequeDate);
            builder.Property(x => x.DueDate);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required FKs

            builder.Property(x => x.CashPaymentId).IsRequired();
            builder.Property(x => x.PaymentModeId).IsRequired();
            builder.Property(x => x.AccountId).IsRequired();

            // Relationships

            // Parent CashReceipt
            builder.HasOne(x => x.CashPayment)
                   .WithMany()
                   .HasForeignKey(x => x.CashPaymentId);

            // Payment Mode
            builder.HasOne(x => x.ModeOfPayment)
                   .WithMany()
                   .HasForeignKey(x => x.PaymentModeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Account
            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.AccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Bank (Optional)
            builder.HasOne(x => x.Bank)
                   .WithMany()
                   .HasForeignKey(x => x.BankId)
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