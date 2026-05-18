using Inspection.Domain.Models.Accounting.AR.SalesInvoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AR.SalesInvoices
{
    public class SalesInvoiceSalesPersonConfiguration : IEntityTypeConfiguration<SalesInvoiceSalesPerson>
    {
        public void Configure(EntityTypeBuilder<SalesInvoiceSalesPerson> builder)
        {
            builder.ToTable("SalesInvoiceSalesPerson", "Accounting");

            builder.HasKey(x => x.Id);


            // Properties


            builder.Property(x => x.Percentage)
                   .IsRequired()
                   .HasPrecision(5, 2);

            // ========================
            // Relationships
            // ========================

            // Parent SalesInvoice
            builder.HasOne(x => x.SalesInvoice)
                   .WithMany(x => x.SalesInvoiceSalesPersons)
                   .HasForeignKey(x => x.SalesInvoiceId);

            // SalesPerson
            builder.HasOne(x => x.SalesPerson)
                   .WithMany()
                   .HasForeignKey(x => x.SalesPersonId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ========================
            // Audit
            // ========================

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