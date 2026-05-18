using Inspection.Domain.Models.EquipmentManagement.CompanyEquipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.EquipmentManagement.CompanyEquipments
{

    public class CompanyEquipmentConfig : IEntityTypeConfiguration<CompanyEquipment>
    {
        public void Configure(EntityTypeBuilder<CompanyEquipment> builder)
        {
            builder.ToTable("CompanyEquipment", "Inspection");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CalibrationStatus);
            builder.Property(x => x.Description)
                   .IsRequired();
        }
    }
}