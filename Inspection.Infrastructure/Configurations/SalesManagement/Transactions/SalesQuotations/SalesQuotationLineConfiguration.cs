using Inspection.Domain.Models.SalesManagment.Transaction.SalesQuotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SalesManagement.Transactions.SalesQuotations
{
    public class SalesQuotationLineConfiguration : IEntityTypeConfiguration<SalesQuotationLine>
    {
        public void Configure(EntityTypeBuilder<SalesQuotationLine> builder)
        {
            builder.ToTable("SalesQuotationLine", "Sales");

            // -------------------- PK --------------------
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.SalesQuotationId);

            // -------------------- Properties --------------------
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.UnitPrice).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.Total).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(500);

            // -------------------- Audit --------------------
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // -------------------- Required FKs --------------------
            builder.Property(x => x.SalesQuotationId).IsRequired();
            builder.Property(x => x.ItemId).IsRequired();

            // -------------------- Relationships --------------------

            // Parent SalesQuotation
            builder.HasOne(x => x.SalesQuotation)
                   .WithMany()
                   .HasForeignKey(x => x.SalesQuotationId);

            // Item
            builder.HasOne(x => x.Item)
                   .WithMany()
                   .HasForeignKey(x => x.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Inspection Method (Optional)
            builder.HasOne(x => x.InspectionMethod)
                   .WithMany()
                   .HasForeignKey(x => x.InspectionMethodId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}