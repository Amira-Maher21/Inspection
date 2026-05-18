using Inspection.Domain.Models.Accounting.AccountingSetup.Cashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.Caching
{
    public class CashConfigration : IEntityTypeConfiguration<Cash>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<Cash> builder)
        {
            builder.ToTable("Cash", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID)
                   .IsRequired();


            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            builder.Property(x => x.BranchId);

            builder.Property(x => x.CurrencyId)
                   .IsRequired();

            builder.Property(x => x.CashOnHandAccountId)
                   .IsRequired();

            builder.HasIndex(x => new { x.Tenant_ID, x.Code })
                   .IsUnique();


            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.CashOnHandAccountId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}