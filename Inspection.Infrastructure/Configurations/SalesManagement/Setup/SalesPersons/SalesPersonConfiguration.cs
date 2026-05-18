using Inspection.Domain.Models.SalesManagment.Setup.SalesPersons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SalesManagement.Setup.SalesPersons
{
    public class SalesPersonConfiguration : IEntityTypeConfiguration<SalesPerson>
    {
        public void Configure(EntityTypeBuilder<SalesPerson> builder)
        {
            builder.ToTable("SalesPerson", "Sales");

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Tenant_ID).HasMaxLength(10);

            builder.Property(x => x.Code)
                  .IsRequired()
                  .HasMaxLength(20);

            builder.Property(x => x.Name)
                  .IsRequired()
                  .HasMaxLength(150);

            builder.Property(x => x.Email)
                  .HasMaxLength(150);

            builder.Property(x => x.Mobile)
                  .HasMaxLength(20);

            builder.Property(x => x.Phone)
                  .HasMaxLength(20);

            builder.Property(x => x.MaxDiscountPercent)
                   .HasPrecision(5, 2)
                   .HasDefaultValue(0);

            builder.Property(x => x.CanApproveQuotation)
                   .HasDefaultValue(false);

            builder.Property(x => x.TargetAmount)
                   .HasPrecision(18, 2);

            builder.Property(x => x.HireDate)
                   .HasColumnType("date");

            builder.Property(x => x.SalesRole)
                  .HasConversion<int>();

            builder.HasOne(x => x.User_Code)
                    .WithMany()
                    .HasForeignKey(x => x.User_CodeId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
