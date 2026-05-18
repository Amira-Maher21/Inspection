using Inspection.Domain.Models.System.Taxes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.System.Taxes
{
    public class TaxTypeConfig : IEntityTypeConfiguration<TaxType>
    {
        public void Configure(EntityTypeBuilder<TaxType> builder)
        {
            builder.ToTable("TaxType", "Accounting");


            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Description)
                  .HasMaxLength(500);


            builder.Property(x => x.Percentage)
                   .HasColumnType("decimal(18,6)")
                   .IsRequired();

            builder.Property(x => x.IsActive)
                    .HasDefaultValue(false);
            builder.Property(x => x.IsRecoverable);
            builder.Property(x => x.IsInclusive);

            builder.Property(x => x.IsExempt)
                   .IsRequired();


            builder.Property(x => x.EtaCodeEgypt)
                   .HasMaxLength(200);

            builder.Property(x => x.IsSystem)
                   .IsRequired();

            builder.HasMany(x => x.TaxTypeLine)
                  .WithOne(x => x.TaxType)
                  .HasForeignKey(x => x.TaxTypeId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Foreign Keys

            builder.HasOne(x => x.taxCategory)
                   .WithMany()
                   .HasForeignKey(x => x.taxCategoryId);

            builder.HasOne(x => x.TaxAccount)
                   .WithMany()
                   .HasForeignKey(x => x.TaxAccountId);


            builder.Property(x => x.Tenant_ID)
                   .IsRequired();


            builder.Property(x => x.In_User)
                       .IsRequired()
                       .HasMaxLength(100);
            builder.Property(x => x.In_Date);
            builder.Property(x => x.Mod_User)
                      .HasMaxLength(100);
            builder.Property(x => x.Mod_Date);


            builder.HasIndex(x => new { x.Tenant_ID, x.Code })
                   .IsUnique();

        }

    }
}