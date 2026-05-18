using Inspection.Domain.Models.Contracting.Setup.Divisions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Contracting.Setup.Divisions
{
    public class DivisionConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.ToTable("Division", "Contracting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID).IsRequired();
            builder.Property(x => x.CompanyId).IsRequired();

            builder.Property(x => x.DivisionCode)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(x => x.DivisionName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.IsLeaf)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.DivisionCode })
                   .IsUnique();

            builder.HasOne<Division>()
                   .WithMany()
                   .HasForeignKey(x => x.ParentDivisionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}