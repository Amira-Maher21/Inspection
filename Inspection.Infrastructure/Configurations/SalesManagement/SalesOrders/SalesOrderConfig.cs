using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SalesManagement.SalesOrders
{
    public class SalesOrderConfig : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            builder.ToTable("SalesOrder", "Sales");
            builder.HasKey(x => x.Id);

            // Required Fields
            builder.Property(x => x.OrderNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.CompanyId)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Notes)
                   .HasMaxLength(500);

            builder.Property(x => x.DocumentStatusCancelledReason)
                   .HasMaxLength(500);

            // Precision
            builder.Property(x => x.SubTotal).HasPrecision(18, 2);
            builder.Property(x => x.Discount).HasPrecision(18, 2);
            builder.Property(x => x.TotalAmount).HasPrecision(18, 2);

            // Relationships

            builder.HasOne(x => x.Customer)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SalesQuotation)
                   .WithMany()
                   .HasForeignKey(x => x.SalesQuotationId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PaymentTerm)
                   .WithMany()
                   .HasForeignKey(x => x.PaymentTermId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Salesperson)
                   .WithMany()
                   .HasForeignKey(x => x.SalespersonId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Lines relation
            builder.HasMany(x => x.SalesOrderLines)
                   .WithOne(x => x.SalesOrder)
                   .HasForeignKey(x => x.SalesOrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(e => new { e.OrderNumber, e.Tenant_ID })
                   .HasDatabaseName("UX_SalesOrder_OrderNumber_Tenant")
                   .IsUnique();

            builder.HasIndex(x => x.CustomerId);
            builder.HasIndex(x => x.OrderDate);
            builder.HasIndex(x => x.DocumentStatus);
        }
    }
}