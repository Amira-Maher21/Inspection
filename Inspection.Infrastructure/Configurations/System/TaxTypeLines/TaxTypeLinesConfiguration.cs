using Inspection.Domain.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.System.TaxTypeLines
{
    public class TaxTypeLinesConfiguration : IEntityTypeConfiguration<TaxTypeLine>
    {
        public void Configure(EntityTypeBuilder<TaxTypeLine> builder)
        {
            builder.ToTable("TaxTypeLine", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DocumentDirection)
                   .IsRequired();

            builder.Property(x => x.RecoverablePercentage)
                   .HasColumnType("decimal(5,2)");


            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.ChartOfAccountId)
                   .OnDelete(DeleteBehavior.Restrict);


            //builder.HasOne(x => x.TaxType)
            //       .WithMany(x => x.TaxTypeLine)
            //       .HasForeignKey(x => x.TaxTypeId)
            //       .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.TaxTypeId, x.DocumentDirection })
                  .IsUnique();

            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);
        }
    }
}