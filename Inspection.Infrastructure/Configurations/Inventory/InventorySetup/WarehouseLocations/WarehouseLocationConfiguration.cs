using Inspection.Domain.Models.Inventory.InventorySetup.WarehouseLocations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.InventorySetup.WarehouseLocations
{


    public class WarehouseLocationConfiguration : IEntityTypeConfiguration<WarehouseLocation>
    {
        public void Configure(EntityTypeBuilder<WarehouseLocation> builder)
        {
            builder.ToTable("WarehouseLocation", "Inventory");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID).IsRequired();
            builder.Property(x => x.WarehouseId)
            .IsRequired();
            builder.Property(x => x.Code)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(x => x.LocationType)
               .HasMaxLength(50)
               .IsRequired();
            builder.Property(x => x.IsLeaf)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.Capacity)
                .HasPrecision(18, 6);
            builder.Property(x => x.Description)
                .HasMaxLength(250);


            builder.HasOne<WarehouseLocation>()
                 .WithMany()
                 .HasForeignKey(x => x.ParentLocationId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.WarehouseId, x.Tenant_ID, x.Code })
                  .IsUnique()
                  .HasDatabaseName("UQ_WarehouseLocation_Code");




        }
    }
}



