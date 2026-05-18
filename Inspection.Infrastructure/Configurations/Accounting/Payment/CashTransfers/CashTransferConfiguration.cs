using Inspection.Domain.Models.Accounting.Payment.CashTransfers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.CashTransfers
{
    public class CashTransferConfiguration : IEntityTypeConfiguration<CashTransfer>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<CashTransfer> builder)
        {
            builder.ToTable("CashTransfer", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Unique Index
            // (Tenant + Company + Branch + TransferNumber)
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.BranchId, x.TransferNumber }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.TransferNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TransferDate).IsRequired();
            builder.Property(x => x.Amount).IsRequired().HasPrecision(18, 6);
            builder.Property(x => x.IsInTransit).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(500);
            builder.Property(x => x.ReferenceNumber).HasMaxLength(200);
            builder.Property(x => x.ReferenceDate);

            // Enums
            builder.Property(x => x.Posting).IsRequired();

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required Relationships
            builder.Property(x => x.BranchId).IsRequired();
            builder.Property(x => x.FiscalYearId).IsRequired();
            builder.Property(x => x.ChartOfAccountFromId).IsRequired();
            builder.Property(x => x.ChartOfAccountToId).IsRequired();
            builder.Property(x => x.ModeOfPaymentFromId).IsRequired();
            builder.Property(x => x.ModeOfPaymentToId).IsRequired();
            builder.Property(x => x.CurrencyId).IsRequired();

            // Relationships

            // Adjustments
            builder.HasMany(x => x.CashTransferLines)
                   .WithOne(x => x.CashTransfer)
                   .HasForeignKey(x => x.CashTransferId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Branch
            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            // FiscalYear
            builder.HasOne(x => x.FiscalYear)
                   .WithMany()
                   .HasForeignKey(x => x.FiscalYearId)
                   .OnDelete(DeleteBehavior.Restrict);

            // From Account
            builder.HasOne(x => x.ChartOfAccountFrom)
                   .WithMany()
                   .HasForeignKey(x => x.ChartOfAccountFromId)
                   .OnDelete(DeleteBehavior.Restrict);

            // To Account
            builder.HasOne(x => x.ChartOfAccountTo)
                   .WithMany()
                   .HasForeignKey(x => x.ChartOfAccountToId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Mode Of Payment From
            builder.HasOne(x => x.ModeOfPaymentFrom)
                   .WithMany()
                   .HasForeignKey(x => x.ModeOfPaymentFromId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Mode Of Payment To
            builder.HasOne(x => x.ModeOfPaymentTo)
                   .WithMany()
                   .HasForeignKey(x => x.ModeOfPaymentToId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Currency
            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Series
            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);

            // CHECK CONSTRAINTS

            // Posting values
            builder.HasCheckConstraint(
                "CK_CashTransfer_Posting",
                "[Posting] IN (1,2,3)"
            );

            // Amount > 0
            builder.HasCheckConstraint(
                "CK_CashTransfer_Amount",
                "[Amount] > 0"
            );

            // Prevent same account transfer
            builder.HasCheckConstraint(
                "CK_CashTransfer_DifferentAccounts",
                "[ChartOfAccountFromId] <> [ChartOfAccountToId]"
            );
        }
    }
}