using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Contracting.Setup.Commitments
{

    public class ProductionOrderLineConfig : IEntityTypeConfiguration<ProductionOrderLine>
    {
        public void Configure(EntityTypeBuilder<ProductionOrderLine> builder)
        {
            builder.ToTable("ProductionOrderLine", "Manufacturing");
            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => x.ProductionOrderId);

            // Properties
            builder.Property(x => x.Quantity).IsRequired().HasPrecision(18, 4);
            builder.Property(x => x.UnitRate).IsRequired().HasPrecision(18, 4);
            builder.Property(x => x.Amount).IsRequired().HasPrecision(18, 2);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required FKs
            builder.Property(x => x.ItemId).IsRequired();
            builder.Property(x => x.WBSId).IsRequired();
            builder.Property(x => x.CostCodeId).IsRequired();

            // Relationships
            builder.HasOne(x => x.WBS)
                 .WithMany()
                 .HasForeignKey(x => x.WBSId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CostCode)
                   .WithMany()
                   .HasForeignKey(x => x.CostCodeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ProductionOrder)
                   .WithMany()
                   .HasForeignKey(x => x.ProductionOrderId)
                   .OnDelete(DeleteBehavior.Restrict);


            // Parent Commitment
            builder.HasOne(x => x.ProductionOrder)
                   .WithMany(x => x.ProductionOrderLines)
                   .HasForeignKey(x => x.ProductionOrderId);

            // CHECK CONSTRAINTS




        }
    }
}