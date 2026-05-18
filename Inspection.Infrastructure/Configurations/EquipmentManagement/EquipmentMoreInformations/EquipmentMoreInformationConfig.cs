using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.EquipmentManagement.EquipmentMoreInformations
{
    public class EquipmentMoreInformationConfig : IEntityTypeConfiguration<EquipmentsMoreInformation>
    {
        public void Configure(EntityTypeBuilder<EquipmentsMoreInformation> builder)
        {
            builder.ToTable("EquipmentsMoreInformation", "Inspection");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.EquipmentTypes)
                   .WithMany()
                   .HasForeignKey(x => x.EquipmentTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}