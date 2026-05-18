using Inspection.Domain.Models.System.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.System.Languages
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Language", "syst");

            builder.HasKey(x => x.LocaleCode);

            builder.Property(x => x.LocaleCode)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.ISOCode)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(x => x.Direction)
                   .IsRequired();

            builder.Property(x => x.Active)
                   .IsRequired();

            builder.Property(x => x.Tenant_ID)
                   .IsRequired();

            builder.Property(x => x.In_User)
                     .IsRequired()
                     .HasMaxLength(100);
            builder.Property(x => x.In_Date);
            builder.Property(x => x.Mod_User)
                      .HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

        }
    }
}