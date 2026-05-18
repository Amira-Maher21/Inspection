using Inspection.Domain.Models.SalesManagment.Transaction.DeliveryNotes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SalesManagment.Transactions.DeliveryNotes
{
    public class DeliveryNoteConfiguration : IEntityTypeConfiguration<DeliveryNote>
    {
        public void Configure(EntityTypeBuilder<DeliveryNote> builder)
        {
            builder.ToTable("DeliveryNote", "Sales");

            builder.HasKey(x => x.Id);

            // ========================
            // Properties
            // ========================

            builder.Property(x => x.DeliveryNoteNo)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.TotalAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.NetAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.TaxAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.AdditionalDiscountValue)
                   .HasPrecision(18, 6);

            builder.Property(x => x.AdditionalDiscountAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.TotalDiscount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.ShipmentAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.Notes)
                   .HasMaxLength(500);

            builder.Property(x => x.CustomerPurchaseOrder)
                   .HasMaxLength(100);

            builder.Property(x => x.ShipmentAddress)
                   .HasMaxLength(500);

            builder.Property(x => x.DeliveryPersonName)
                   .HasMaxLength(200);

            // ========================
            // Enums
            // ========================

            builder.Property(x => x.Posting)
                   .HasConversion<int>();

            builder.Property(x => x.ShipmentStatus)
                   .HasConversion<int>();

            builder.Property(x => x.ShipmentMethod)
                   .HasConversion<int>();

            builder.Property(x => x.AdditionalDiscountType)
                   .HasConversion<int>();

            builder.Property(x => x.ApprovalStatus)
                   .HasConversion<int>();

            // ========================
            // Audit
            // ========================

            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

            // ========================
            // Relationships
            // ========================

            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Warehouse)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Customer)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SalesOrder)
                   .WithMany()
                   .HasForeignKey(x => x.SalesOrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SalesInvoice)
                   .WithMany()
                   .HasForeignKey(x => x.SalesInvoiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PaymentTerm)
                   .WithMany()
                   .HasForeignKey(x => x.PaymentTermId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ========================
            // Collections
            // ========================

            builder.HasMany(x => x.DeliveryNoteLines)
                   .WithOne(x => x.DeliveryNote)
                   .HasForeignKey(x => x.DeliveryNoteId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}