using Inspection.Domain.Models.InspectionManagement.CustomerProjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.InspectionManagement.CustomerProjects
{
    public class CustomerProjectConfig : IEntityTypeConfiguration<CustomerProject>
    {
        public void Configure(EntityTypeBuilder<CustomerProject> builder)
        {
            builder.ToTable("CustomerProject", "Inspection");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CustomerId).IsRequired().HasMaxLength(150);
            builder.Property(x => x.ProjectCode).IsRequired().HasMaxLength(150);
            builder.Property(x => x.ProjectName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Location).IsRequired().HasMaxLength(500);
            builder.Property(x => x.BuildingNumber).HasMaxLength(150);
            builder.Property(x => x.StreetName).HasMaxLength(150);
            builder.Property(x => x.District).HasMaxLength(150);
            builder.Property(x => x.City).HasMaxLength(150);
            builder.Property(x => x.PostalCode).HasMaxLength(150);
            builder.Property(x => x.AdditionalNumber).HasMaxLength(150);
            builder.Property(x => x.GPSLatitude).HasMaxLength(150);
            builder.Property(x => x.GPSLongitude).HasMaxLength(150);

            builder.Property(x => x.Notes).HasColumnType("nvarchar(max)");//.IsRequired(false);
        }
    }
}