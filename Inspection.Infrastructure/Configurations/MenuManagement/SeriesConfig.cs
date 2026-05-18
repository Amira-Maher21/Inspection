using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.MenuManagement
{
    public class SeriesConfig : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.ToTable("Series", "Stt");

            builder.HasIndex(s => new { s.Tenant_ID, s.ScreenCode_Id }).IsUnique();
        }
    }
}
