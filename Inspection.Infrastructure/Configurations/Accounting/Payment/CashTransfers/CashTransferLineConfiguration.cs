using Inspection.Domain.Models.Accounting.Payment.CashTransfers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.CashTransfers
{
    public class CashTransferLineConfiguration : IEntityTypeConfiguration<CashTransferLine>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<CashTransferLine> builder)
        {
            builder.ToTable("CashTransferLine", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => x.CashTransferId);

            // Properties
            builder.Property(x => x.Amount).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.Notes).HasMaxLength(250);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required FKs
            builder.Property(x => x.CashTransferId).IsRequired();
            builder.Property(x => x.ChartOfAccountId).IsRequired();

            // Relationships

            // Parent CashTransfer
            builder.HasOne(x => x.CashTransfer)
                   .WithMany(x => x.CashTransferLines)
                   .HasForeignKey(x => x.CashTransferId);

            // Chart Of Account
            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.ChartOfAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            // CHECK CONSTRAINTS

            // Amount > 0
            builder.HasCheckConstraint(
                "CK_CashTransferLine_Amount",
                "[Amount] > 0"
            );
        }
    }
}