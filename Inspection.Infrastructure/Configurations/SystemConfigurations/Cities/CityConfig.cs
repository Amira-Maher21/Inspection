using Inspection.Domain.Models.SystemConfigurations.Cities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SystemConfigurations.Cities
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City", "Sec");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.Code }).IsUnique();

            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            // ✅ Database-level validation
            builder.HasCheckConstraint(
                "CK_City_Code_MustContainLetter",
                "Code LIKE '%[A-Za-z]%'"
            );

            builder.HasCheckConstraint(
                "CK_City_Name_MustContainLetter",
                "Name LIKE '%[A-Za-z]%'"
            );

            builder.HasOne(x => x.Country)
                 .WithMany()
                 .HasForeignKey(x => x.CountryId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);
        }
    }
}