using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.EquipmentManagement.EquipmentMoreInformationTemplateDetails
{

    public class EquipmentMoreInformationTemplateDetailConfig : IEntityTypeConfiguration<EquipmentsMoreInformationTemplateDetail>
    {
        public void Configure(EntityTypeBuilder<EquipmentsMoreInformationTemplateDetail> builder)
        {
            builder.ToTable("EquipmentsMoreInformationTemplateDetail", "Inspection");
            builder.HasKey(x => x.Id);

            builder.HasIndex(e => new { e.KeyName, e.Tenant_ID })
                   .HasDatabaseName("UX_EquipmentMoreInformationTemplateDetail_KeyName_Tenant")
                   .IsUnique();
        }
    }
}