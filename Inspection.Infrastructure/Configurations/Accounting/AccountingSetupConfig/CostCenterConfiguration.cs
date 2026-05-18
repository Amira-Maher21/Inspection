using Inspection.Domain.Models.Accounting.AccountingSetup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig
{
    public class CostCenterConfiguration : IEntityTypeConfiguration<CostCenter>
    {
        public void Configure(EntityTypeBuilder<CostCenter> builder)
        {
            builder.ToTable("CostCenter", "Accounting");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.Code }).IsUnique();

            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasOne<CostCenter>()
                  .WithMany()
                  .HasForeignKey(x => x.ParentCostCenterId)
                  .OnDelete(DeleteBehavior.Restrict);


            builder.Property(x => x.IsMain)
                  .IsRequired()
                  .HasDefaultValue(true);
            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();








            builder.HasOne(x => x.Department)
                  .WithMany()
                  .HasForeignKey(x => x.DepartmentId)
                  .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(x => x.ParentCostCenter)
            //      .WithMany()
            //      .HasForeignKey(x => x.ParentCostCenterId)
            //      .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
