using Inspection.Domain.Models.Inventory.Transaction.InventoryOpeningsBalance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.Transaction.InventoryOpeningBalances
{
    public class InventoryOpeningBalanceConfiguration : IEntityTypeConfiguration<InventoryOpeningBalance>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<InventoryOpeningBalance> builder)
        {
            builder.ToTable("InventoryOpeningBalance", "Inventory");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Unique Index
            // (Tenant + Company + Warehouse + FiscalYear)
            builder.HasIndex(x => new
            {
                x.Tenant_ID,
                x.CompanyId,
                x.WarehouseId,
                x.FiscalYearId
            }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.WarehouseId).IsRequired();
            builder.Property(x => x.FiscalYearId).IsRequired();
            builder.Property(x => x.BranchId).IsRequired();
            builder.Property(x => x.CurrencyId).IsRequired();
            builder.Property(x => x.TotalValue).IsRequired().HasPrecision(18, 6);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.YearEndCarryForward).HasDefaultValue(false);

            // Enums
            builder.Property(x => x.Posting).IsRequired();

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Relationships

            // Warehouse
            builder.HasOne(x => x.Warehouse)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Fiscal Year
            builder.HasOne(x => x.FiscalYear)
                   .WithMany()
                   .HasForeignKey(x => x.FiscalYearId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Branch
            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Currency
            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Details (Lines)
            builder.HasMany(x => x.InventoryOpeningBalanceLines)
                   .WithOne(x => x.InventoryOpeningBalance)
                   .HasForeignKey(x => x.InventoryOpeningBalanceId)
                   .OnDelete(DeleteBehavior.Cascade);

            //// CHECK CONSTRAINTS

            //// Ensure TotalValue >= 0
            //builder.HasCheckConstraint(
            //    "CK_InventoryOpeningBalance_TotalValue_Positive",
            //    "[TotalValue] >= 0"
            //);

            //// Ensure Posting Enum valid (1=Draft,2=Posted,3=Cancelled)
            //builder.HasCheckConstraint(
            //    "CK_InventoryOpeningBalance_Posting_Valid",
            //    "[Posting] IN (1,2,3)"
            //);

            ////  BUSINESS GUARD (Soft DB Rule)

            //// Prevent "fake" modifications (partial protection only)
            //builder.HasCheckConstraint(
            //    "CK_InventoryOpeningBalance_YearEndCarryForward_ReadOnly",
            //    "[YearEndCarryForward] = 0 OR [Mod_Date] IS NULL"
            //);
        }
    }
}