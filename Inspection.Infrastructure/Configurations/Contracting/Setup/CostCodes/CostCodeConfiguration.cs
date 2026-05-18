using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Contracting.Setup.CostCodes
{
    public class CostCodeConfiguration : IEntityTypeConfiguration<CostCode>
    {
        public void Configure(EntityTypeBuilder<CostCode> builder)
        {
            builder.ToTable("CostCode", "Contracting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID).IsRequired();
            builder.Property(x => x.CompanyId).IsRequired();

            builder.Property(x => x.CostCodeValue)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.CostCodeName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.IsLeaf)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.CostCodeValue })
                   .IsUnique();

            // FK → Division
            builder.HasOne(x => x.Division)
                   .WithMany()
                   .HasForeignKey(x => x.DivisionId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Self Reference
            builder.HasOne<CostCode>()
                   .WithMany()
                   .HasForeignKey(x => x.ParentCostCodeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}