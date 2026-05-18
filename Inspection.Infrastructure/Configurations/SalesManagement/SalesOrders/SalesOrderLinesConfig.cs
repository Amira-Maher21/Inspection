using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SalesManagement.SalesOrders
{
    public class SalesOrderLinesConfig : IEntityTypeConfiguration<SalesOrderLines>
    {
        public void Configure(EntityTypeBuilder<SalesOrderLines> builder)
        {
            builder.ToTable("SalesOrderLine", "Sales");
            builder.HasKey(x => x.Id);

            // Precision
            builder.Property(x => x.Quantity).HasPrecision(18, 2);
            builder.Property(x => x.UnitPrice).HasPrecision(18, 2);
            builder.Property(x => x.TotalPrice).HasPrecision(18, 2);
            builder.Property(x => x.TaxRate).HasPrecision(18, 2);
            builder.Property(x => x.Discount).HasPrecision(18, 2);
            builder.Property(x => x.Notes).HasMaxLength(500);

            // Relationships

            builder.HasOne(x => x.SalesOrder)
                   .WithMany(x => x.SalesOrderLines)
                   .HasForeignKey(x => x.SalesOrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Item)
                   .WithMany()
                   .HasForeignKey(x => x.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.UnitOfMeasure)
                   .WithMany()
                   .HasForeignKey(x => x.UOMId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Warehouse)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(x => x.SalesOrderId);
            builder.HasIndex(x => x.ItemId);
        }
    }
}