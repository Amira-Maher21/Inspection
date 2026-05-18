using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.FiscalYears
{
    public class FiscalYearConfig : IEntityTypeConfiguration<FiscalYear>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<FiscalYear> builder)
        {
            builder.ToTable("FiscalYear", "Accounting");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.Code }).IsUnique();

            // Required Fields

            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(50);



            builder.Property(x => x.StartDate)
                   .IsRequired();

            builder.Property(x => x.EndDate)
                   .IsRequired();

            builder.Property(x => x.IsClosed)
                   .IsRequired();

            // Audit Fields

            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

            builder.HasCheckConstraint(
                "CK_FiscalYear_StartDate_EndDate",
                "[StartDate] < [EndDate]"
            );
        }
    }
}