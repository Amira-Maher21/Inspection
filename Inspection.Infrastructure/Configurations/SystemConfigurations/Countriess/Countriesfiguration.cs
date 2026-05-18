using Inspection.Domain.Models.SystemConfigurations.Countriess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SystemConfigurations.Countriess
{
    public class Countriesfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country", "Sec");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.Code }).IsUnique();

            builder.Property(x => x.Tenant_ID).IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Code).IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Name).IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.In_User).IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date).IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);
        }
    }
}