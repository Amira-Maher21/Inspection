using Inspection.Domain.Models.Inspection.Techinal.InspectionStandards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inspection.Techinal.InspectionStandards
{
    public class InspectionStandardConfiguration
        : IEntityTypeConfiguration<InspectionStandard>
    {
        public void Configure(EntityTypeBuilder<InspectionStandard> builder)
        {
            builder.ToTable("InspectionStandard", "Inspection");

            // PK
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Code)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasIndex(x => x.Code)
                   .IsUnique();

            builder.Property(x => x.Name)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Authority)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.Version)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.Scope)
                   .HasMaxLength(500);
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.Code }).IsUnique()
                .HasDatabaseName("UQ_Item_Company_Code_Tenant");

            // Audit

            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);

            builder.Property(x => x.In_Date).IsRequired();

            builder.Property(x => x.Mod_User).HasMaxLength(100);

            builder.Property(x => x.Mod_Date);
        }
    }
}
