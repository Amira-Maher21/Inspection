using Inspection.Domain.Models.Contracting.Setup.BOQs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Contracting.Setup.BOQs
{
    public class BOQLineConfiguration : IEntityTypeConfiguration<BOQLine>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<BOQLine> builder)
        {
            builder.ToTable("BOQLine", "Contracting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => x.BOQId);

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
            builder.Property(x => x.BOQId).IsRequired();

            // Relationships
            // Parent BOQ
            builder.HasOne(x => x.BOQ)
                   .WithMany(x => x.BOQLines)
                   .HasForeignKey(x => x.BOQId)
                   .OnDelete(DeleteBehavior.Cascade);

            // CHECK CONSTRAINTS

            // Quantity > 0
            builder.HasCheckConstraint(
                "CK_BOQLine_Quantity",
                "[Quantity] > 0"
            );

            // Rate >= 0
            builder.HasCheckConstraint(
                "CK_BOQLine_Rate",
                "[Rate] >= 0"
            );

            // Amount = Quantity * Rate
            builder.HasCheckConstraint(
                "CK_BOQLine_Amount",
                "[Amount] = [Quantity] * [Rate]"
            );
        }
    }
}