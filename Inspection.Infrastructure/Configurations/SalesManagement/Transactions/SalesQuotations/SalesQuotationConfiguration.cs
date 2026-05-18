using Inspection.Domain.Models.SalesManagment.Transaction.SalesQuotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SalesManagement.Transactions.SalesQuotations
{
    public class SalesQuotationConfiguration : IEntityTypeConfiguration<SalesQuotation>
    {

        public void Configure(EntityTypeBuilder<SalesQuotation> builder)
        {
            builder.ToTable("SalesQuotation", "Sales");

            // -------------------- PK --------------------
            builder.HasKey(x => x.Id);

            // -------------------- Index --------------------
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.QuotationNumber }).IsUnique();

            // -------------------- Properties --------------------
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired().HasMaxLength(50);
            builder.Property(x => x.QuotationNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.VersionNumber).HasMaxLength(50);
            builder.Property(x => x.PONumber).HasMaxLength(100);
            builder.Property(x => x.TermsAndConditions).HasMaxLength(2000);
            builder.Property(x => x.CustomerNote).HasMaxLength(1000);
            builder.Property(x => x.DocumentStatusCancelled).HasMaxLength(500);
            builder.Property(x => x.DocumentStatusDeclined).HasMaxLength(500);

            // -------------------- Dates --------------------
            builder.Property(x => x.QuotationDate);
            builder.Property(x => x.ValidUntil);

            // -------------------- Amounts --------------------
            builder.Property(x => x.Discount).HasPrecision(18, 2);
            builder.Property(x => x.TotalAmount).HasPrecision(18, 2).IsRequired();

            // -------------------- Enums --------------------
            builder.Property(x => x.DocumentStatus).IsRequired();
            builder.Property(x => x.ApprovalStatus).IsRequired();

            // -------------------- Audit --------------------
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // -------------------- Relationships --------------------

            // Customer
            builder.Property(x => x.CustomerId).IsRequired();
            builder.HasOne(x => x.Customer)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Inspection Request (Optional)
            builder.HasOne(x => x.InspectionRequest)
                   .WithMany()
                   .HasForeignKey(x => x.InspectionRequestId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Salesperson (Optional)
            builder.HasOne(x => x.Salesperson)
                   .WithMany()
                   .HasForeignKey(x => x.SalespersonId)
                   .OnDelete(DeleteBehavior.Restrict);

            // TaxType (Optional)
            builder.HasOne(x => x.TaxType)
                   .WithMany()
                   .HasForeignKey(x => x.TaxTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Currency (Optional)
            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Series
            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);

            // -------------------- Details --------------------
            builder.HasMany(x => x.SalesQuotationLines)
                   .WithOne()
                   .HasForeignKey(x => x.SalesQuotationId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}