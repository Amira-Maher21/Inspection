using Inspection.Domain.Models.Inventory.InventorySetup.UnitOfMeasureConversions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.InventorySetup.UnitOfMeasureConversionConversions
{
    public class UnitOfMeasureConversionConfigration : IEntityTypeConfiguration<UnitOfMeasureConversion>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasureConversion> builder)
        {
            builder.ToTable("UnitOfMeasureConversion", "Inventory");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ConversionFactor)
                   .HasColumnType("decimal(18,6)")
                   .IsRequired();

            builder.HasOne(x => x.FromUnitOfMeasure)
                   .WithMany()
                   .HasForeignKey(x => x.FromUoMId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_UoMConversion_FromUoM");

            builder.HasOne(x => x.ToUnitOfMeasure)
                   .WithMany()
                   .HasForeignKey(x => x.ToUoMId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_UoMConversion_ToUoM");

            builder.HasIndex(x => new { x.FromUoMId, x.ToUoMId })
                   .IsUnique()
                   .HasDatabaseName("UQ_UoMConversion_From_To");

            builder.Property(x => x.Tenant_ID)
                   .IsRequired();

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
