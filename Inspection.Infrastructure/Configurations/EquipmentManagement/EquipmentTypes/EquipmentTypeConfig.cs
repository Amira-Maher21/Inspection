using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.EquipmentManagement.EquipmentTypes
{
    public class EquipmentTypeConfig : IEntityTypeConfiguration<EquipmentType>
    {
        public void Configure(EntityTypeBuilder<EquipmentType> builder)
        {
            builder.ToTable("EquipmentType", "Inspection");
            builder.HasKey(x => x.Id);

            builder.HasIndex(e => new { e.Code, e.Tenant_ID })
                       .HasDatabaseName("UX_EquipmentType_Code_Tenant")
                       .IsUnique();
            builder.HasIndex(x => x.Name);

        }
    }
}