using Inspection.Domain.Models.EquipmentManagement.EquipmentAccessories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.EquipmentManagement.EquipmentAccessories
{

    public class EquipmentAccessoriesConfig : IEntityTypeConfiguration<EquipmentAccessory>
    {
        public void Configure(EntityTypeBuilder<EquipmentAccessory> builder)
        {
            builder.ToTable("EquipmentAccessory", "Inspection");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status);
        }
    }
}