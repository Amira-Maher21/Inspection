using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfoTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.EquipmentManagement.EquipmentMoreInformationTemplates
{

    public class EquipmentMoreInformationTemplateConfig : IEntityTypeConfiguration<EquipmentsMoreInformationTemplate>
    {
        public void Configure(EntityTypeBuilder<EquipmentsMoreInformationTemplate> builder)
        {
            builder.ToTable("EquipmentsMoreInformationTemplate", "Inspection");
            builder.HasKey(x => x.Id);

            // DETAIL → SUB-DETAIL
            builder
                .HasMany(m => m.EquipmentsMoreInformationTemplateDetails)
                .WithOne(d => d.EquipmentsMoreInformationTemplates)
                .HasForeignKey(d => d.EquipmentsMoreInformationTemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            // EquipmentType relation (NO CASCADE)
            builder
                .HasOne(m => m.EquipmentTypes)
                .WithMany()
                .HasForeignKey(m => m.EquipmentTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}