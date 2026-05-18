using Inspection.Domain.Models.SystemConfigurations.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SystemConfigurations.Operations
{

    public class OperationConfig : IEntityTypeConfiguration<Operation>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.ToTable("Operation", "Sec");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.AwardDate).IsRequired();
            builder.Property(x => x.Location).IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IsClosed).HasDefaultValue(false);
            builder.Property(x => x.PlannedStartDate);
            builder.Property(x => x.PlannedEndDate);
            builder.Property(x => x.ClosedDate);


            // PlannedEndDate >= PlannedStartDate
            builder.HasCheckConstraint(
     "CK_Operation_PlannedDates",
     "([PlannedStartDate] IS NULL AND [PlannedEndDate] IS NULL) " +
     "OR ([PlannedStartDate] IS NOT NULL AND [PlannedEndDate] IS NOT NULL AND [PlannedEndDate] >= [PlannedStartDate])"
 );


            // Foreign Keys

            builder.HasOne(x => x.operationType)
                   .WithMany()
                   .HasForeignKey(x => x.OperationTypeId);

            builder.HasOne(x => x.customer)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.costCenter)
                   .WithMany()
                   .HasForeignKey(x => x.CostCenterId);

            builder.HasOne(x => x.costUnit)
                   .WithMany()
                   .HasForeignKey(x => x.CostUnitId);

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.Code }).IsUnique();
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.Name }).IsUnique();

            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);
        }
    }
}