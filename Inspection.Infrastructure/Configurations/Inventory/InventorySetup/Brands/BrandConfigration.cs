using Inspection.Domain.Models.Inventory.InventorySetup.Brands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.InventorySetup.Brands
{
    public class BrandConfigration : IEntityTypeConfiguration<Brand>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand", "Inventory");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID)
                   .IsRequired();

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(150);


            builder.Property(x => x.Description)
                   .HasMaxLength(255);

            builder.HasIndex(x => new { x.Code, x.Tenant_ID })
                   .IsUnique()
                   .HasDatabaseName("UQ_Brand_Code_Tenant");
        }
    }
}
