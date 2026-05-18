using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Manufacturing.Setup.ProductionOrders
{

    public class ProductionOrderConfig : IEntityTypeConfiguration<ProductionOrder>
    {
        public void Configure(EntityTypeBuilder<ProductionOrder> builder)
        {
            builder.ToTable("ProductionOrder", "Manufacturing");
            // Primary Key
            builder.HasKey(x => x.Id);

            // Unique Index
            // (Tenant + Company + OrderNumber)
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.OrderNumber }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.OrderNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ExpectedAmount).HasPrecision(18, 2);

            // Enums

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required Relationships
            builder.Property(x => x.OperationId).IsRequired();

            // ProductionOrderLine
            builder.HasMany(x => x.ProductionOrderLines)
                   .WithOne(x => x.ProductionOrder)
                   .HasForeignKey(x => x.ProductionOrderId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}