using Inspection.Domain.Models.Accounting.PR.PurchaseInvoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.PR.PurchaseInvoices
{
    public class PurchaseInvoiceAdjustmentConfiguration : IEntityTypeConfiguration<PurchaseInvoiceAdjustment>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoiceAdjustment> builder)
        {
            builder.ToTable("PurchaseInvoiceAdjustment", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);



            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            // Indexes
            builder.HasIndex(x => x.PurchaseInvoiceId);

            // Properties
            builder.Property(x => x.Amount)
                   .IsRequired()
                   .HasPrecision(18, 6);

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            // Audit
            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

            // Relationships
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



            builder.HasOne(x => x.PurchaseInvoice)
                   .WithMany(x => x.Adjustments)
                   .HasForeignKey(x => x.PurchaseInvoiceId)
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
        }
    }
}