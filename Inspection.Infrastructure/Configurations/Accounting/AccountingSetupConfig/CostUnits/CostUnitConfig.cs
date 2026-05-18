using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.CostUnits
{
    public class CostUnitConfig : IEntityTypeConfiguration<CostUnit>
    {
        public void Configure(EntityTypeBuilder<CostUnit> builder)
        {
            builder.ToTable("CostUnit", "Accounting");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.Code }).IsUnique();

            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.CompanyId)
                   .IsRequired();

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.IsMain)
                   .IsRequired()
                   .HasDefaultValue(true);

            // Audit Fields
            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);
        }
    }
}