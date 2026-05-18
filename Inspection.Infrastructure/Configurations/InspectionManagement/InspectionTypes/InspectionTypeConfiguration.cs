using Inspection.Domain.Models.InspectionManagement.InspectionTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.InspectionManagement.InspectionTypes
{
    public class InspectionTypeConfiguration : IEntityTypeConfiguration<InspectionType>
    {
        public void Configure(EntityTypeBuilder<InspectionType> builder)
        {
            builder.ToTable("InspectionType", "Inspection");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.Code }).IsUnique();

            // Required Fields
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CompanyId).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Code).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);

            // Audit Fields
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);
        }
    }
}