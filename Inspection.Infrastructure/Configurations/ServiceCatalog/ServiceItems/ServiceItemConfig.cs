using Inspection.Domain.Models.InspectionManagement.ServicesItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.ServiceCatalog.ServiceItems
{


    public class ServiceItemConfig : IEntityTypeConfiguration<ServiceItem>
    {
        public void Configure(EntityTypeBuilder<ServiceItem> builder)
        {
            builder.ToTable("ServiceItem", "Inspection");

            builder.HasKey(x => x.Id);

            builder.HasIndex(e => new { e.Itemcode, e.Tenant_ID })
        .HasDatabaseName("UX_ServiceItem_Itemcode_Tenant")
        .IsUnique();
        }
    }
}