using Inspection.Domain.Models.EquipmentManagement.Equipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.EquipmentManagement.Equipments
{
    public class EquipmentConfig : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipment", "Inspection");

            builder.HasKey(x => x.Id);

            // ================= Required Fields =================

            builder.Property(x => x.EquipmentNo).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);

            // ================= Optional Fields =================

            builder.Property(x => x.SerialNumber).HasMaxLength(100);
            builder.Property(x => x.Model).HasMaxLength(100);
            builder.Property(x => x.Manufacturer).HasMaxLength(150);
            builder.Property(x => x.Dimensions).HasMaxLength(200);
            builder.Property(x => x.Material).HasMaxLength(150);
            builder.Property(x => x.Notes).HasMaxLength(150);

            // ================= Decimal Precision =================

            builder.Property(x => x.Capacity).HasPrecision(18, 4);
            builder.Property(x => x.PowerRating).HasPrecision(18, 4);
            builder.Property(x => x.Voltage).HasPrecision(18, 4);
            builder.Property(x => x.Pressure).HasPrecision(18, 4);
            builder.Property(x => x.Weight).HasPrecision(18, 4);

            // ================= Unique Constraint =================
            // Unique (Tenant, Company, EquipmentNo)

            builder.HasIndex(e => new { e.Tenant_ID, e.CompanyId, e.EquipmentNo })
                   .HasDatabaseName("UX_Equipment_Tenant_Company_EquipmentNo")
                   .IsUnique();

            // ================= Relations =================

            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EquipmentType)
                   .WithMany()
                   .HasForeignKey(x => x.EquipmentTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Customer)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CustomerProject)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerProjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CustomerLocation)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerLocationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}