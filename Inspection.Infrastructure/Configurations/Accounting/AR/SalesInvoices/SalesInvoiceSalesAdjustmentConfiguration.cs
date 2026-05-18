using Inspection.Domain.Models.Accounting.AR.SalesInvoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AR.SalesInvoices
{
    public class SalesInvoiceSalesAdjustmentConfiguration : IEntityTypeConfiguration<SalesInvoiceSalesAdjustment>
    {
        public void Configure(EntityTypeBuilder<SalesInvoiceSalesAdjustment> builder)
        {
            builder.ToTable("SalesInvoiceSalesAdjustment", "Accounting");

            builder.HasKey(x => x.Id);



            // ========================
            // Properties
            // ========================

            builder.Property(x => x.Amount)
                    .IsRequired()
                    .HasPrecision(18, 6);

            builder.Property(x => x.Description)
                   .HasMaxLength(250);

            // ========================
            // Relationships
            // ========================

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

            builder.HasOne(x => x.SalesInvoice)
                  .WithMany(x => x.SalesInvoiceSalesAdjustments)
                  .HasForeignKey(x => x.SalesInvoiceId);

            builder.HasOne(x => x.ChartOfAccount)
                  .WithMany()
                  .HasForeignKey(x => x.ChartOfAccountId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CostCenter)
                  .WithMany()
                  .HasForeignKey(x => x.CostCentertId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CostUnit)
                   .WithMany()
                   .HasForeignKey(x => x.CostUnitId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Operation)
                   .WithMany()
                   .HasForeignKey(x => x.OperationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ========================
            // Audit
            // ========================

            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

        }
    }
}