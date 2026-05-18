using Inspection.Domain.Models.Accounting.AccountingSetup.AccountingPeriods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.AccountingPeriods
{
    public class AccountingPeriodConfig : IEntityTypeConfiguration<AccountingPeriod>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<AccountingPeriod> builder)
        {
            builder.ToTable("AccountingPeriod", "Accounting");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.Code, x.FiscalYearId })
                   .IsUnique();

            builder.HasIndex(x => new { x.CompanyId, x.FiscalYearId });

            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.CompanyId)
                   .IsRequired();

            builder.Property(x => x.FiscalYearId)
                   .IsRequired();

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(50);


            builder.Property(x => x.StartDate)
                   .IsRequired();

            builder.Property(x => x.EndDate)
                   .IsRequired();

            builder.Property(x => x.LockDate)
                   .IsRequired();

            builder.Property(x => x.IsClosed)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.HasOne(x => x.FiscalYear)
                   .WithMany()
                   .HasForeignKey(x => x.FiscalYearId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Optional Check Constraints
            builder.HasCheckConstraint(
                "CK_AccountingPeriod_DateRange",
                "[EndDate] >= [StartDate]");

            builder.HasCheckConstraint(
                "CK_AccountingPeriod_LockDate",
                "[LockDate] >= [StartDate] AND [LockDate] <= [EndDate]");
        }
    }
}