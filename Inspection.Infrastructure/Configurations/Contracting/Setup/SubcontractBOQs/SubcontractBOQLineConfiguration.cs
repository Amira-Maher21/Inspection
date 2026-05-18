using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Contracting.Setup.SubcontractBOQs
{
    public class SubcontractBOQLineConfiguration : IEntityTypeConfiguration<SubcontractBOQLine>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<SubcontractBOQLine> builder)
        {
            builder.ToTable("SubcontractBOQLine", "Contracting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => x.SubcontractBOQId);

            // Properties
            builder.Property(x => x.BOQItemCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.UnitId).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Quantity).IsRequired().HasPrecision(18, 4);
            builder.Property(x => x.Rate).IsRequired().HasPrecision(18, 4);
            builder.Property(x => x.Amount).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.WBSId);
            builder.Property(x => x.CostCodeId);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required FK
            builder.HasOne(x => x.WBS)
                  .WithMany()
                  .HasForeignKey(x => x.WBSId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CostCode)
                  .WithMany()
                  .HasForeignKey(x => x.CostCodeId)
                  .OnDelete(DeleteBehavior.Restrict);


            builder.Property(x => x.SubcontractBOQId).IsRequired();

            // Relationships
            // Parent SubcontractBOQ
            builder.HasOne(x => x.SubcontractBOQ)
                   .WithMany(x => x.SubcontractBOQLines)
                   .HasForeignKey(x => x.SubcontractBOQId)
                   .OnDelete(DeleteBehavior.Cascade);

            // CHECK CONSTRAINTS

            // Quantity > 0
            builder.HasCheckConstraint(
                "CK_SubcontractBOQLine_Quantity",
                "[Quantity] > 0"
            );

            // Rate >= 0
            builder.HasCheckConstraint(
                "CK_SubcontractBOQLine_Rate",
                "[Rate] >= 0"
            );

            // Amount = Quantity * Rate
            builder.HasCheckConstraint(
                "CK_SubcontractBOQLine_Amount",
                "[Amount] = [Quantity] * [Rate]"
            );
        }
    }
}