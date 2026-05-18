using Inspection.Domain.Models.InspectionManagement.CustomerLocations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.InspectionManagement.CustomerLocations
{


    public class GoodsReceiptConfiguration : IEntityTypeConfiguration<CustomerLocation>
    {
        public void Configure(EntityTypeBuilder<CustomerLocation> builder)
        {
            builder.ToTable("CustomerLocation", "Inspection");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CustomerId).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Location).IsRequired().HasMaxLength(500);
            builder.Property(x => x.BuildingNumber).HasMaxLength(150);
            builder.Property(x => x.StreetName).HasMaxLength(150);
            builder.Property(x => x.District).HasMaxLength(150);
            builder.Property(x => x.City).HasMaxLength(150);
            builder.Property(x => x.PostalCode).HasMaxLength(150);
            builder.Property(x => x.AdditionalNumber).HasMaxLength(150);
            builder.Property(x => x.GPSLatitude).HasMaxLength(150);
            builder.Property(x => x.GPSLongitude).HasMaxLength(150);
            builder.Property(x => x.Notes).HasColumnType("nvarchar(max)");
        }
    }
}