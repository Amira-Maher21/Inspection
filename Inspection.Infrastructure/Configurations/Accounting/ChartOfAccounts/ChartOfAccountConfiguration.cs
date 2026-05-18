using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.ChartOfAccounts
{
    public class ChartOfAccountConfiguration : IEntityTypeConfiguration<ChartOfAccount>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<ChartOfAccount> builder)
        {
            builder.ToTable("ChartOfAccount", "Accounting");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.AccountCode }).IsUnique();

            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);

            builder.Property(x => x.AccountCode).IsRequired().HasMaxLength(50);

            builder.Property(x => x.AccountName).IsRequired().HasMaxLength(300);

            builder.Property(x => x.Level).IsRequired();

            builder.Property(x => x.IsMain).IsRequired();

            builder.Property(x => x.AccountTypeCode).IsRequired().HasMaxLength(50);

            builder.Property(x => x.ParentAccountId).HasMaxLength(50);

            // Defaults
            builder.Property(x => x.IsDisable)
                   .HasDefaultValue(false);

            builder.Property(x => x.IsCostCenterRequired)
                   .HasDefaultValue(false);

            builder.Property(x => x.IsCostUnitRequired)
                   .HasDefaultValue(false);

            builder.Property(x => x.IsControlAccount)
                   .HasDefaultValue(false);

            builder.Property(x => x.IsReconciliationAccount)
                   .HasDefaultValue(false);

            builder.Property(x => x.IsCashAccount)
                   .HasDefaultValue(false);

            builder.Property(x => x.IsBankAccount)
                   .HasDefaultValue(false);

            // Audit

            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);

            builder.Property(x => x.In_Date).IsRequired();

            builder.Property(x => x.Mod_User).HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

            // Relationships

            // AccountType (Required)
            builder.HasOne(x => x.AccountType)
                   .WithMany()
                   .HasForeignKey(x => x.AccountTypeCode)
                   .OnDelete(DeleteBehavior.Restrict);

            // Currency (Optional)
            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            // CostUnit (Optional)
            builder.HasOne(x => x.CostUnit)
                   .WithMany()
                   .HasForeignKey(x => x.CostUnitId)
                   .OnDelete(DeleteBehavior.Restrict);

            // CostCenter (Optional)
            builder.HasOne(x => x.CostCenter)
                   .WithMany()
                   .HasForeignKey(x => x.CostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Self-Reference (Hierarchy)
            builder.HasOne<ChartOfAccount>()
                   .WithMany()
                   .HasForeignKey(x => x.ParentAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Check Constraints

            // Level must be >= 1
            builder.HasCheckConstraint(
                "CK_ChartOfAccount_Level",
                "[Level] >= 1");

            // Parent is required when not main
            builder.HasCheckConstraint(
                "CK_ChartOfAccount_Parent_When_Not_Main",
                "([IsMain] = 1 AND [ParentAccountId] IS NULL) OR " +
                "([IsMain] = 0 AND [ParentAccountId] IS NOT NULL)");

            // CostCenter required rule
            builder.HasCheckConstraint(
                "CK_ChartOfAccount_CostCenter_Required",
                "([IsCostCenterRequired] = 0) OR ([CostCenterId] IS NOT NULL)");

            // CostUnit required rule
            builder.HasCheckConstraint(
                "CK_ChartOfAccount_CostUnit_Required",
                "([IsCostUnitRequired] = 0) OR ([CostUnitId] IS NOT NULL)");
        }
    }
}