using Inspection.Domain.Models.Inventory.Ledger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.LedgerConfig
{
    public class LedgerLineConfig : IEntityTypeConfiguration<LedgerLine>
    {
        public void Configure(EntityTypeBuilder<LedgerLine> builder)
        {
            builder.ToTable("LedgerLine", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            // ========================
            // Money Precision
            // ========================

            builder.Property(x => x.DebitAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(x => x.CreditAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            // ========================
            // Relationships
            // ========================

            builder.HasOne(x => x.Ledger)
                   .WithMany(x => x.LedgerLines)
                   .HasForeignKey(x => x.LedgerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.ChartOfAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CostCenter)
                   .WithMany()
                   .HasForeignKey(x => x.CostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CostUnit)
                   .WithMany()
                   .HasForeignKey(x => x.CostUnitId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Operation)
                   .WithMany()
                   .HasForeignKey(x => x.OperationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Customer)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerId)
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



            builder.HasOne(x => x.Supplier)
                     .WithMany()
                     .HasForeignKey(x => x.SupplierId)
                     .OnDelete(DeleteBehavior.Restrict);

            // ========================
            // Accounting Rule
            // ========================

            //builder.HasCheckConstraint(
            //    "CK_LedgerLine_Amount",
            //    "([DebitAmount] > 0 AND [CreditAmount] = 0) OR " +
            //    "([CreditAmount] > 0 AND [DebitAmount] = 0)"
            //);

            // ========================
            // Useful Indexes
            // ========================

            builder.HasIndex(x => x.LedgerId);
            builder.HasIndex(x => x.ChartOfAccountId);
            builder.HasIndex(x => x.CostCenterId);
            builder.HasIndex(x => x.OperationId);

        }
    }
}
