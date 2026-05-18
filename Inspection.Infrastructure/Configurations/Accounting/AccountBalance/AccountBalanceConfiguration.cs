using Inspection.Domain.Models.Accounting;
using Inspection.Domain.Models.Accounting.AccountBalance;
using Inspection.Domain.Models.Inventory.System.InventoryLedgers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.System.InventoryLedgers
{

    public class AccountBalanceConfiguration
        : IEntityTypeConfiguration<AccountBalance>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<AccountBalance> builder)
        {
            builder.ToTable("AccountBalance", "Accounting");

            // ================= PK =================
            builder.HasKey(x => x.Id);

            // ================= Properties =================
            builder.Property(x => x.Tenant_ID)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CompanyId)
                .IsRequired();

            builder.Property(x => x.ChartOfAccountId)
                .IsRequired();

            builder.Property(x => x.TotalDebit)
                .HasPrecision(18, 6)
                .HasDefaultValue(0);

            builder.Property(x => x.TotalCredit)
                .HasPrecision(18, 6)
                .HasDefaultValue(0);

            // ================= Relation =================
            builder.HasOne(x => x.ChartOfAccount)
                .WithMany()
                .HasForeignKey(x => x.ChartOfAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // ================= Composite Index =================
            builder.HasIndex(x => new
            {
                x.Tenant_ID,
                x.CompanyId,
                x.ChartOfAccountId
            })
            .IsUnique();

        }
    }
}