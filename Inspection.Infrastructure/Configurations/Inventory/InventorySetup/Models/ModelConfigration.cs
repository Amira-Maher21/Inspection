using Inspection.Domain.Models.Inventory.InventorySetup.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.InventorySetup.Models
{
    public class ModelConfigration : IEntityTypeConfiguration<Model>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Model", "Inventory");

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


            builder.HasOne(x => x.Brand)
                   .WithMany()
                   .HasForeignKey(x => x.BrandId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new
            {
                x.Code,
                x.Tenant_ID
            })
                   .IsUnique()
                   .HasDatabaseName("UQ_Model_Code_Tenant");
        }
    }
}
