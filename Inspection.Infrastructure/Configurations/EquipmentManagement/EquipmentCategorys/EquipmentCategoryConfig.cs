using Inspection.Domain.Models.EquipmentManagement.EquipmentCategorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.EquipmentManagement.EquipmentCategorys
{
    public class EquipmentCategoryConfig : IEntityTypeConfiguration<EquipmentCategory>
    {
        public void Configure(EntityTypeBuilder<EquipmentCategory> builder)
        {
            builder.ToTable("EquipmentCategory", "Inspection");

            builder.HasKey(x => x.Id);

            builder.HasIndex(e => new { e.Name, e.Tenant_ID })
        .HasDatabaseName("UX_EquipmentCategory_Name_Tenant")
        .IsUnique();
        }
    }
}