using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.EquipmentManagement.EquipmentMoreInformationDetails
{
    public class EquipmentMoreInformationDetailConfig : IEntityTypeConfiguration<EquipmentsMoreInformationDetail>
    {
        public void Configure(EntityTypeBuilder<EquipmentsMoreInformationDetail> builder)
        {
            builder.ToTable("EquipmentsMoreInformationDetail", "Inspection");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.EquipmentsMoreInformations)
                   .WithMany(x => x.EquipmentsMoreInformationDetails)
                   .HasForeignKey(x => x.EquipmentsMoreInformationId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}