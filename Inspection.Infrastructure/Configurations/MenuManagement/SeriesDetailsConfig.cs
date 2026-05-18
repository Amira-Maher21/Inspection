using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.MenuManagement
{
    public class SeriesDetailsConfig : IEntityTypeConfiguration<SeriesDetails>
    {
        public void Configure(EntityTypeBuilder<SeriesDetails> builder)
        {
            builder.ToTable("SeriesDetails", "Stt");
            builder.HasKey(x => x.Id);
            builder.HasIndex(s => new { s.Tenant_ID, s.SeriesId });

        }
    }
}