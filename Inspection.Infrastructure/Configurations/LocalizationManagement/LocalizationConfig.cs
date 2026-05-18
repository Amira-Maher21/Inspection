using Inspection.Domain.Models.Localizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.LocalizationManagement
{
    public class LocalizationConfig : IEntityTypeConfiguration<Localization>
    {
        public void Configure(EntityTypeBuilder<Localization> builder)
        {
            builder.ToTable("Localization", "Syst");
            builder.HasKey(e => new { e.LocaleCode, e.Caption });
            builder.Property(e => e.LocaleCode).IsRequired().HasMaxLength(10);
            builder.Property(e => e.Caption).HasMaxLength(500);
            builder.Property(e => e.Tooltip).HasMaxLength(500);
            builder.Property(e => e.System);
        }
    }
}