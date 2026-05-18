using Inspection.Domain.Models.Inventory.InventorySetup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.InventorySetup
{
    public class UnitOfMeasureConfigration : IEntityTypeConfiguration<UnitOfMeasure>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
        {
            // Table
            builder.ToTable("UnitOfMeasure", "Inventory");

            // Primary Key
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Description)
                   .HasMaxLength(255);

            builder.Property(x => x.IsBaseUnit)
                   .IsRequired();

            // Audit Fields
            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

            // Unique Index (Code + Tenant)
            builder.HasIndex(x => new { x.Code, x.Tenant_ID })
                   .IsUnique()
                   .HasDatabaseName("UQ_UnitOfMeasure_Code_Tenant");


            builder.Property(x => x.Tenant_ID)
                   .IsRequired();


        }
    }
}
